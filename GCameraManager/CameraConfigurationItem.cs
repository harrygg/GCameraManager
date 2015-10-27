using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ozeki.Camera;
using Ozeki.Media.MediaHandlers.Video;
using Ozeki.Media.MediaHandlers;
using Ozeki.Media.Video.Controls;
using System.Windows.Controls;
using System.Timers;
using System.IO;
using Ozeki.Camera.Data;
using Ozeki.Media.IPCamera;

namespace GCameraManager
{
  class CameraConfigurationItem
  {
    public OzekiCamera camera;
    DrawingImageProvider provider;
    MotionDetector detector;
    MediaConnector connector;
    MPEG4Recorder recorder;
    static VideoResizer videoResizer;
		public string id;
		public VideoViewerWF videoViewer;

		//public delegate void ConnectedEventHandler(object sender, EventArgs e);
		//public delegate void DisonnectedEventHandler(object sender, EventArgs e);

		#region Events
		public delegate void EventHandler(object sender, CameraStateEventArgs e);

    /// <summary>
    /// Event will be raised when camera state is changed
    /// </summary>
    public event EventHandler<CameraStateEventArgs> CameraStateChanged;
    protected void OnCameraStateChanged(object sender, CameraStateEventArgs e)
    {
      if (CameraStateChanged != null)
        CameraStateChanged(this, e); //Change the sender to this CCI
    }
    public event EventHandler<CameraErrorEventArgs> CameraErrorOccurred;
    protected void OnCameraErrorOccurred(object sender, CameraErrorEventArgs e)
    {
      var handler = CameraErrorOccurred;
      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Event that will be raised when the camera starts/ends video capturing
    /// </summary>
    public VideoCapturingState videoCapturingState;
    public event EventHandler<VideoCapturingEventArgs> VideoCapturingStateChanged;
    protected void OnVideoCapturingStateChanged(object sender, VideoCapturingEventArgs e)
    {
      //Set the video capturing state for later use within this class
      videoCapturingState = e.CapturingState;

      //Raise the event if there are subscribers
      if (VideoCapturingStateChanged != null)
        VideoCapturingStateChanged(sender, e);
    }
    #endregion
		
    public CameraConfigurationItem(string cameraId, VideoViewerWF videoViewer)
    {
      this.videoViewer = videoViewer;
			this.id = cameraId;
      provider = new DrawingImageProvider();
      connector = new MediaConnector();
      detector = new MotionDetector();
      videoResizer = new VideoResizer();
			detector.PixelIntensitySensitivy = Settings.PixelIntensitySensitivity; //0-255
			detector.PixelAmountSensitivy = Settings.PixelAmountSensitivity; //0-10

			videoViewer.SetImageProvider(provider);
    }

    internal void Connect(string url)
    {
      if (camera != null)
        Disconnect();

      camera = new OzekiCamera(url);
      camera.CameraStateChanged += OnCameraStateChanged;
      camera.CameraErrorOccurred += OnCameraErrorOccurred;

			Log.Write("StopVideoCapturing() Connecting camera.VideoChannel and detector");
			connector.Connect(camera.VideoChannel, detector);
      //connector.Connect(detector, provider); //Needed if we want to highlight the motion on screen
			Log.Write("StopVideoCapturing() Connecting camera.VideoChannel and provider");
      connector.Connect(camera.VideoChannel, provider);

      camera.Start();
			if (videoViewerVisible)
				videoViewer.Start();
    }

		bool videoViewerVisible = false;
		public bool VideoViewerVisible { get { return videoViewerVisible; } set { videoViewerVisible = value; } }

    internal void Disconnect()
    {
      if (camera == null) 
        return;

      videoViewer.Stop();
      camera.Stop();

			Log.Write("StopVideoCapturing() Disconnecting camera.VideoChannel and detector");
			connector.Disconnect(camera.VideoChannel, detector);
			Log.Write("StopVideoCapturing() Disconnecting camera.VideoChannel and provider");
      connector.Disconnect(camera.VideoChannel, provider);
			//connector.Disconnect(detector, provider);
			camera = null;
    }

    internal void CancelRecording()
    {
      //If we are not capturing video
      if (camera.VideoChannel == null || recorder == null)
        return;

      //Raise event 
      OnVideoCapturingStateChanged(this, new VideoCapturingEventArgs(VideoCapturingState.Stopping));

      StopVideoCapturing();

      if (Settings.RecordOnMotion)
      {
        detector.MotionDetection -= OnMotionDetection;
        detector.Dispose();
      }
    }

    void StopVideoCapturing()
    {
      Log.Write("StopVideoCapturing() started");
      Log.Write("StopVideoCapturing() camera.VideoChannel = " + camera.VideoChannel);
      Log.Write("StopVideoCapturing() recorder = " + recorder);
      Log.Write("StopVideoCapturing() recorder.VideoRecorder = " + recorder.VideoRecorder);

      //If we are capturing video
      if (camera.VideoChannel != null && recorder.VideoRecorder != null)
      {
				//connector.Disconnect(camera.VideoChannel, recorder.VideoRecorder);
				Log.Write("StopVideoCapturing() Disconnecting camera.VideoChannel and videoResizer");
				connector.Disconnect(camera.VideoChannel, videoResizer);
				Log.Write("StopVideoCapturing() Disconnecting videoResizer and recorder.VideoRecorder");
				connector.Disconnect(videoResizer, recorder.VideoRecorder);
        //Multiplex and compress audio and video in a single track
        Log.Write("StopVideoCapturing() calling recorder.Multiplex()");
        recorder.Multiplex();
      }

      var state = videoCapturingState.Equals(VideoCapturingState.Stopping) ? VideoCapturingState.Stopped : VideoCapturingState.WaitingForMotion;
      OnVideoCapturingStateChanged(this, new VideoCapturingEventArgs(state));

      Log.Write("StopVideoCapturing() ended");
    }
    
    void recorder_MultiplexFinished(object sender, Ozeki.VoIP.VoIPEventArgs<bool> e)
    {
      Log.Write("recorder_MultiplexFinished() started");
      var mp4Recorder = sender as MPEG4Recorder;

      //connector.Disconnect(_camera.AudioChannel, recorder.AudioRecorder);
      //connector.Disconnect(camera.VideoChannel, recorder.VideoRecorder);
      mp4Recorder.MultiplexFinished -= recorder_MultiplexFinished;
      mp4Recorder.Dispose();
      //Task.Factory.StartNew(FtpUploadOnNewThread);
      Log.Write("recorder_MultiplexFinished() ended");
    }

    internal void StartRecording()
    {
      if (Settings.RecordOnMotion)
        StartRecordingOnMotionDetection();
      else //If recording on motion detection is not enabled
        StartVideoCapturing();
    }

    void StartRecordingOnMotionDetection()
    {
      detector.MotionDetection += OnMotionDetection;
      detector.Start();
      OnVideoCapturingStateChanged(this, new VideoCapturingEventArgs(VideoCapturingState.WaitingForMotion));
    }
		
    Timer minRecTimer;
    Timer maxRecTimer;
		bool inMotion;

		void OnMotionDetection(object sender, MotionDetectionEvent e)
    {
			inMotion = e.Detection;
      Log.Write("OnMotionDetection(" + e.Detection + ") started");
      if (e.Detection)
      {
        //If we are already recording when motion was detected
        if (videoCapturingState.Equals(VideoCapturingState.Recording))
          return;
        StartVideoCapturing();
      }
      else
      {
        //If motion has stopped and minimum recording time has elapsed stop the recording
        Log.Write("OnMotionDetection(" + e.Detection + ") minRecTimer.Enabled == " + minRecTimer.Enabled);
        if (!minRecTimer.Enabled)
        {
          Log.Write("OnMotionDetection(" + e.Detection + ") Motion ended, minimum timer ended. Stopping video capturing");
          StopVideoCapturing();
        }
      }
      Log.Write("OnMotionDetection(" + e.Detection + ") ended");
    }

		/// <summary>
		/// Start capturing video 
		/// </summary>
		void StartVideoCapturing()
		{
			Log.Write("StartVideoCapturing() started");

			if (camera.VideoChannel != null)
			{
				Log.Write("StartVideoCapturing() Camera" + id + ".CurrentFrameRate: " + camera.CurrentFrameRate.ToString());
				videoResizer.SetOptions(camera.Resolution, camera.CurrentFrameRate);
				Log.Write("StopVideoCapturing() Connecting camera.VideoChannel and videoResizer");
				connector.Connect(camera.VideoChannel, videoResizer);

				var filePath = GetFileName();
				Log.Write("StartVideoCapturing() Video file path set to: " + filePath);
				recorder = new MPEG4Recorder(filePath);
				Log.Write("StopVideoCapturing() Connecting videoResizer and recorder.VideoRecorder");
				connector.Connect(videoResizer, recorder.VideoRecorder);
				recorder.MultiplexFinished += recorder_MultiplexFinished;
				//connector.Connect(_camera.AudioChannel, _recorder.AudioRecorder);

				if (Settings.RecordOnMotion)
				{
					StartTimer(minRecTimer, Settings.MinVideoLength);
					StartTimer(maxRecTimer, Settings.MaxVideoLength);
				}
				//Raise recording event
				OnVideoCapturingStateChanged(this, new VideoCapturingEventArgs(VideoCapturingState.Recording));
			}
			Log.Write("StartVideoCapturing() ended");
		}

		void StartTimer(Timer timer, double time)
		{
			timer = new Timer();
			timer.Interval = time * 1000;
			timer.AutoReset = false; // Raise Elapsed event only the first time it elapsed

			if (time == Settings.MinVideoLength)
			{
				Log.Write("StartTimer() Mintimer started!");
				timer.Elapsed += (send, args) => MinRecordingTimeElapsed(send, recorder);
			}
			else
			{
				Log.Write("StartTimer() Maxtimer started!");
				timer.Elapsed += (send, args) => MaxRecordingTimeElapsed(send, recorder);
			}
			timer.Start();
		}

		void StopTimer(Timer timer)
		{
			if (timer != null)
			{
				timer.Stop();
				timer.Dispose();
			}
		}

		/// <summary>
		/// Maximum video length time has ellapsed
		/// Stop all recording, 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="recorder"></param>
		void MaxRecordingTimeElapsed(object sender, MPEG4Recorder recorder)
		{
			Log.Write("MaxRecordingTimeElapsed() started");
			if (!videoCapturingState.Equals(VideoCapturingState.Recording))
				return;

			StopTimer(minRecTimer);
			Log.Write("MaxRecordingTimeElapsed() MaxTimer ended!");
			StopVideoCapturing();

			//If there is still motion, start a new recording
			if (inMotion)
			{
				Log.Write("MaxRecordingTimeElapsed() inMotion == true, so starting a new recording");
				StartVideoCapturing();
			}
			//connector.Disconnect(camera.VideoChannel, recorder.VideoRecorder);
			Log.Write("MaxRecordingTimeElapsed() ended");
		}

		void MinRecordingTimeElapsed(object sender, MPEG4Recorder recorder)
		{
			Log.Write("MinRecordingTimeElapsed() started");

			StopTimer(minRecTimer);
			Log.Write("MinRecordingTimeElapsed() MinTimer ended!");

			//If a false MotionDetectionEvent has been raised, stop the capturing and reset the maxRecTimer
			//otherwise continue with the recording
			Log.Write("motion.Detection == " + inMotion);
			if (!inMotion)
			{
				Log.Write("MinRecordingTimeElapsed() Motion has stopped, stopping the video capturing");
				StopTimer(maxRecTimer);
				Log.Write("MinRecordingTimeElapsed() MaxTimer forced to end!");
				StopVideoCapturing();
			}
			else
				Log.Write("MinRecordingTimeElapsed() There is still motion, so continue with the video capturing");
			//connector.Disconnect(camera.VideoChannel, recorder.VideoRecorder);
			Log.Write("MinRecordingTimeElapsed() ended");
		}

		string GetFileName()
		{
			//Check if directory exists
			string SaveToDir = "";
			if (Directory.Exists(Settings.SaveToDirectory))
			{
				SaveToDir = Path.Combine(Settings.SaveToDirectory, camera.DeviceName.ToString());
				if (!Directory.Exists(SaveToDir))
					Directory.CreateDirectory(SaveToDir);
			}
			var fileName = DateTime.Now.Year + "-" + DateTime.Now.Month.ToString("00") + "-" + DateTime.Now.Day.ToString("00") + "-" +
									DateTime.Now.Hour.ToString("00") + "-" + DateTime.Now.Minute.ToString("00") + "-" + DateTime.Now.Second.ToString("00") + ".mp4";

			return Path.Combine(SaveToDir, fileName);
		}
	}

  public class VideoCapturingEventArgs : EventArgs
  {
    public VideoCapturingEventArgs(bool isRecording)
    {
      this.isRecording = isRecording;
    }
    bool isRecording;
    public bool IsRecording { get { return isRecording; } }

    public VideoCapturingEventArgs(VideoCapturingState state)
    {
      capturingState = state;
    }

    VideoCapturingState capturingState;
    public VideoCapturingState CapturingState { get { return capturingState; } }
  }

  public enum VideoCapturingState
  {
    Error = 0,
    Recording = 10,
    WaitingForMotion = 20,
    Stopping = 30,
    Stopped = 40
  }
  /*
  public class CameraErrorEventArgs : EventArgs
  {
    public string Details { get; }
    public IPCameraError Error { get; }
  }
  
  public enum IPCameraError
  {
    NoError = 5,
    NoEndPoint = 10,
    ConnectionFailure = 20,
    AuthenticationFailure = 30,
    PTZError = 40,
    UnsupportedAudioFormat = 50,
    UnsupportedVideoFormat = 60,
    ConnectionLost = 70,
  }*/
}
