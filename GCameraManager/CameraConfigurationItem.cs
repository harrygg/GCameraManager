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

    public delegate void ConnectedEventHandler(object sender, EventArgs e);
    public delegate void DisonnectedEventHandler(object sender, EventArgs e);
    VideoViewerWF videoViewer;

    #region Events
    public delegate void EventHandler(object sender, CameraStateEventArgs e);

    /// <summary>
    /// Event will be raised when camera state is changed
    /// </summary>
    public event EventHandler<CameraStateEventArgs> CameraStateChanged;
    protected void OnCameraStateChanged(object sender, CameraStateEventArgs e)
    {
      if (CameraStateChanged != null)
        CameraStateChanged(sender, e);
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
    VideoCapturingState videoCapturingState;
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


    public CameraConfigurationItem(VideoViewerWF videoViewer)
    {
      this.videoViewer = videoViewer;
      provider = new DrawingImageProvider();
      connector = new MediaConnector();
      detector = new MotionDetector();
      videoResizer = new VideoResizer();
      //detector.PixelIntensitySensitivy = Convert.ToInt32(pixelIntensitySensitivity.Text); //0-255
      //detector.PixelAmountSensitivy = Convert.ToInt32(pixelAmountSensitivity.Text) / 10; //0-10

      videoViewer.SetImageProvider(provider);
    }

    internal void Initialize(string url)
    {
      if (camera != null)
        Disconnect();

      camera = new OzekiCamera(url);
      camera.CameraStateChanged += OnCameraStateChanged;
      camera.CameraErrorOccurred += OnCameraErrorOccurred;

      connector.Connect(camera.VideoChannel, detector);
      //connector.Connect(detector, provider);
      connector.Connect(camera.VideoChannel, provider);

      camera.Start();
			if (Settings.VideoViewer1Visible)
				videoViewer.Start();
    }


    internal void Disconnect()
    {
      if (camera == null) 
        return;

      videoViewer.Stop();
      camera.Stop();
      connector.Disconnect(camera.VideoChannel, detector);
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
        detector.MotionDetection -= detector_MotionDetection;
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
        connector.Disconnect(camera.VideoChannel, videoResizer);
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

    string SaveToDir = "";

    internal void StartRecording()
    {
      if (Settings.RecordOnMotion)
        StartRecordingOnMotionDetection();
      else //If recording on motion detection is not enabled
        StartVideoCapturing();
    }

    void StartRecordingOnMotionDetection()
    {
      detector.MotionDetection += detector_MotionDetection;
      detector.Start();
      OnVideoCapturingStateChanged(this, new VideoCapturingEventArgs(VideoCapturingState.WaitingForMotion));
    }

    bool inMotion = false;
    bool isMinTimerActive = false;
    bool isMaxTimerActive = false;
    Timer minRecTimer;
    Timer maxRecTimer;

    void detector_MotionDetection(object sender, MotionDetectionEvent e)
    {
      Log.Write("detector_MotionDetection(" + e.Detection + ") started");
      if (e.Detection)
      {
        inMotion = true;
        //If we are already recording when motion was detected
        if (videoCapturingState.Equals(VideoCapturingState.Recording))
          return;
        StartVideoCapturing();
      }
      else
      {
        inMotion = false;
        //If motion has stopped and minimum recording time has elapsed stop the recording
        Log.Write("detector_MotionDetection(" + e.Detection + ") isMinTimerActive == " + isMinTimerActive);
        if (!isMinTimerActive)
        {
          Log.Write("detector_MotionDetection(" + e.Detection + ") Motion ended, minimum timer ended. Stopping video capturing");
          StopVideoCapturing();
        }
      }
      Log.Write("detector_MotionDetection(" + e.Detection + ") ended");
    }

    void MinRecordingTimeElapsed(object sender, MPEG4Recorder recorder)
    {
      Log.Write("MinRecordingTimeElapsed() started");

      var timer = sender as Timer;
      if (timer != null)
      {
        timer.Stop();
        timer.Dispose();
        isMinTimerActive = false;
        Log.Write("MinTimer ended!");
      }

      //If a false MotionDetectionEvent has been raised, stop the capturing and reset the maxRecTimer
      //otherwise continue with the recording
      Log.Write("inMotion == " + inMotion + "");
      if (!inMotion)
      {
        Log.Write("MinRecordingTimeElapsed() Motion has stopped, stopping the video capturing");
        
        if (maxRecTimer != null)
        {
          maxRecTimer.Enabled = false;
          maxRecTimer.Stop();
          maxRecTimer.Dispose();
          isMaxTimerActive = false;
          Log.Write("MaxTimer forced to end!");
        }
        StopVideoCapturing();
      }
      else
        Log.Write("MinRecordingTimeElapsed() There is still motion, so continue with the video capturing");
      //connector.Disconnect(camera.VideoChannel, recorder.VideoRecorder);
      Log.Write("MinRecordingTimeElapsed() ended");
    }

    /// <summary>
    /// Maximum video length time has ellapsed
    /// Stop all recording, 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="recorder"></param>
    void MaxRecordingTimeElapsed(object sender, MPEG4Recorder recorder)
    {
      if (!videoCapturingState.Equals(VideoCapturingState.Recording))
        return;

      Log.Write("MaxRecordingTimeElapsed() started");

      var timer = sender as Timer;
      if (timer != null)
      {
        timer.Stop();
        timer.Dispose();
        isMaxTimerActive = false;
        Log.Write("MaxTimer ended!");
      }

      StopVideoCapturing();

      //If there is still motion, start a new recording
      if (inMotion)
      {
        Log.Write("inMotion == true, so starting a new recording");
        StartVideoCapturing();
      }
      //connector.Disconnect(camera.VideoChannel, recorder.VideoRecorder);
      Log.Write("MaxRecordingTimeElapsed() ended");
    }

    void StartVideoCapturing()
    {
      Log.Write("StartVideoCapturing() started");

      //Check if directory exists
      if (Directory.Exists(Settings.SaveToDirectory))
      {
        SaveToDir = Path.Combine(Settings.SaveToDirectory, camera.DeviceName.ToString());
        if (!Directory.Exists(SaveToDir))
          Directory.CreateDirectory(SaveToDir);
      }

      //ChangeRecordingStatus(recordingStatusLB1, "Recording");
      if (camera.VideoChannel == null)
        return;

      var date = DateTime.Now.Year + "-" + DateTime.Now.Month.ToString("00") + "-" + DateTime.Now.Day.ToString("00") + "-" +
                  DateTime.Now.Hour.ToString("00") + "-" + DateTime.Now.Minute.ToString("00") + "-" + DateTime.Now.Second.ToString("00");

      var currentpath = Path.Combine(SaveToDir, date + ".mp4");

      Log.Write("Camera1 CurrentFrameRate: " + camera.CurrentFrameRate.ToString());
      videoResizer.SetOptions(640, 480, 15);
      connector.Connect(camera.VideoChannel, videoResizer);

      Log.Write("Video file path set to: " + currentpath);
      recorder = new MPEG4Recorder(currentpath);
      connector.Connect(videoResizer, recorder.VideoRecorder);
      recorder.MultiplexFinished += recorder_MultiplexFinished;
      //connector.Connect(_camera.AudioChannel, _recorder.AudioRecorder);

      if (Settings.RecordOnMotion)
      {
        //Start the minimum video lenght timer
        minRecTimer = new Timer();
        maxRecTimer = new Timer();
        minRecTimer.Elapsed += (send, args) => MinRecordingTimeElapsed(send, recorder);
        maxRecTimer.Elapsed += (send, args) => MaxRecordingTimeElapsed(send, recorder);
        minRecTimer.Interval = Settings.MinVideoLength * 1000;
        maxRecTimer.Interval = Settings.MaxVideoLength * 1000;
        minRecTimer.AutoReset = false; // Raise Elapsed event only the first time it elapsed
        maxRecTimer.AutoReset = false;

        minRecTimer.Start();
        isMinTimerActive = true;
        Log.Write("Mintimer started!");
        maxRecTimer.Start();
        isMaxTimerActive = true;
        Log.Write("Maxtimer started!");
      }
      //Raise recording event
      OnVideoCapturingStateChanged(this, new VideoCapturingEventArgs(VideoCapturingState.Recording));

      Log.Write("StartVideoCapturing() ended");
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
