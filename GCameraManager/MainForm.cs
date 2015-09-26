using Ozeki.Camera;
using Ozeki.Camera.Data;
using Ozeki.Media;
using Ozeki.Media.IPCamera;
using Ozeki.Media.MediaHandlers;
using Ozeki.Media.MediaHandlers.Video;
using Ozeki.Media.MediaHandlers.Video.CV;
using Ozeki.Media.Video;
using Ozeki.Media.Video.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCameraManager
{
  public partial class MotionForm : Form
  {
    CameraConfigurationItem ci1;
    CameraConfigurationItem ci2;

    CameraURLBuilderWF cameraUrlBuilder;

    public MotionForm()
    {
      //this.FormClosing += MotionForm_Closing;
      InitializeComponent();
      Log.OnLogMessageReceived += Log_OnLogMessageReceived;

      ci1 = new CameraConfigurationItem(videoViewerWF1);
      ci1.CameraStateChanged += camera_CameraStateChanged;
      ci1.VideoCapturingStateChanged += OnVideoCapturingStateChanged1;

      ci2 = new CameraConfigurationItem(videoViewerWF2);
      ci2.CameraStateChanged += camera2_CameraStateChanged;

      var data = new CameraURLBuilderData { IPCameraEnabled = false };
      cameraUrlBuilder = new CameraURLBuilderWF(data);
 
    }

    #region Events handling

    #region Form events
      void MotionForm_Load(object sender, EventArgs e)
      {
        Log.Write("GCameraManager started!");

        Settings.SaveToDirectory = saveToDirTb1.Text;
        Settings.RecordOnMotion = recordingOnMotionCB.Checked;
        Settings.MinVideoLength = Int32.Parse(minVideoLength.Text);
				Settings.VideoViewer1Visible = viewCamera1.Checked;

        if (!IsValidCameraUrl(cameraUrlTB1.Text))
          connectBtn1.Enabled = false;
        else
        {
          disconnectBtn1.Enabled = false;
          //If connect on startup is enabled
          if (true)
            ci1.Initialize(cameraUrlTB1.Text);
        }

        if (!IsValidCameraUrl(cameraUrlTB2.Text))
          connectBtn2.Enabled = false;
        disconnectBtn2.Enabled = false;
      }

      void MotionForm_Closing(object sender, FormClosingEventArgs e)
      {
        // Display a MsgBox asking the user to save changes or abort. 
        /*if (MessageBox.Show("Do you really want to exit?", "GCameraManager", MessageBoxButtons.YesNo) == DialogResult.No)
        {
          // Cancel the Closing event from closing the form.
          e.Cancel = true;
          return;
        }*/
        //IF Save log file is enabled
        if (saveLogOnExitCb.Checked)
          saveLogTo(Path.Combine(Settings.SaveToDirectory, Log.fileName));
      }
    #endregion

      #region LOG

      void Log_OnLogMessageReceived(object sender, LogEventArgs e)
      {
        InvokeGuiThread(() =>
        {
          logListBox.Items.Add(e.LogMessage);
          LogScroll();
        });
      }

      void LogScroll()
      {
        logListBox.SelectedIndex = logListBox.Items.Count - 1;
        logListBox.SelectedIndex = -1;
      }

      #endregion

    void OnVideoCapturingStateChanged1(object sender, VideoCapturingEventArgs e)
    {
      InvokeGuiThread(() =>
      {
        switch (e.CapturingState)
        {
          case VideoCapturingState.Recording:
            startRecordingBTN1.Enabled = false;
            stopRecordingBTN1.Enabled = true;
            break;
          //case VideoCapturingState.WaitingForMotion:
          //  startRecordingBTN1.Enabled = false;
          //  stopRecordingBTN1.Enabled = true;
          //  break;
          case VideoCapturingState.Stopped:
            startRecordingBTN1.Enabled = true;
            stopRecordingBTN1.Enabled = false;
            break;
        }
      });
      ChangeRecordingStatus(recordingStatusLB1, e.CapturingState.ToString());
      Log.Write("Camera1: Capturing status changed: " + e.CapturingState.ToString());
    }

    void camera_CameraStateChanged(object sender, CameraStateEventArgs e)
    {
      InvokeGuiThread(() =>
      {
        switch (e.State)
        {
          case CameraState.Streaming:
            disconnectBtn1.Enabled = true;
            connectBtn1.Enabled = false;
            //recordingSettingsGB1.Enabled = true;
            composeBtn1.Enabled = false;
            cameraUrlTB1.Enabled = false;
            cameraStateLB1.ForeColor = System.Drawing.Color.Green;
            recordingButtonsGB1.Enabled = true;
            break;
          case CameraState.Disconnected:
            disconnectBtn1.Enabled = false;
            connectBtn1.Enabled = true;
            composeBtn1.Enabled = true;
            cameraUrlTB1.Enabled = true;
            cameraStateLB1.ForeColor = System.Drawing.Color.Red;
            //recordingSettingsGB1.Enabled = false;
            recordingButtonsGB1.Enabled = false;
            break;
          case CameraState.Connected:
            connectBtn1.Enabled = false;
            composeBtn1.Enabled = false;
            disconnectBtn1.Enabled = true;
            cameraUrlTB1.Enabled = false;
            recordingButtonsGB1.Enabled = true;
            cameraStateLB1.ForeColor = System.Drawing.Color.Green;
            break;
          case CameraState.Error:
            connectBtn1.Enabled = true;
            composeBtn1.Enabled = true;
            cameraUrlTB1.Enabled = true;
            cameraStateLB1.ForeColor = System.Drawing.Color.Red;
            //Log error
            break;
        }
      });
      ChangeRecordingStatus(cameraStateLB1, e.State.ToString());
      Log.Write("Camera1: Recording status changed: " + e.State.ToString());
    }


    void camera2_CameraStateChanged(object sender, CameraStateEventArgs e)
    {
      InvokeGuiThread(() =>
      {
        switch (e.State)
        {
          case CameraState.Streaming:
            disconnectBtn2.Enabled = true;
            connectBtn2.Enabled = false;
            composeBtn2.Enabled = false;
            cameraUrlTB2.Enabled = false;
            cameraStateLB2.ForeColor = System.Drawing.Color.Green;
            recordingButtonsGB2.Enabled = true;
            break;
          case CameraState.Disconnected:
            disconnectBtn2.Enabled = false;
            connectBtn2.Enabled = true;
            composeBtn2.Enabled = true;
            cameraUrlTB2.Enabled = true;
            cameraStateLB2.ForeColor = System.Drawing.Color.Red;
            recordingButtonsGB2.Enabled = false;
            break;
          case CameraState.Connected:
            connectBtn2.Enabled = false;
            composeBtn2.Enabled = false;
            disconnectBtn2.Enabled = true;
            cameraUrlTB2.Enabled = false;
            recordingButtonsGB2.Enabled = true;
            cameraStateLB2.ForeColor = System.Drawing.Color.Green;
            break;
          case CameraState.Error:
            connectBtn2.Enabled = true;
            composeBtn2.Enabled = true;
            cameraUrlTB2.Enabled = true;
            cameraStateLB2.ForeColor = System.Drawing.Color.Red;
            //Log error
            break;
        }
      });

      ChangeRecordingStatus(cameraStateLB2, e.State.ToString());
    }

    void camera_CameraErrorOccurred(object sender, CameraErrorEventArgs e)
    {
      InvokeGuiThread(() => Log.Write("Camera error: " + (e.Details ?? e.Error.ToString())));
    }
    #endregion






    bool IsValidCameraUrl(string url)
    {
      //TODO make a real check
      if (url.Length > 0)
        return true;
      return false;
    }

    #region Connect Disconnect Compose buttons

      string GetCameraUrl()
      {
        var result = cameraUrlBuilder.ShowDialog();
        if (result != DialogResult.OK)
          return "";
        Log.Write("Camera url composed: " + cameraUrlBuilder.CameraURL);
        return cameraUrlBuilder.CameraURL;
      }

      void composeBtn1_Click(object sender, EventArgs e)
      {
        cameraUrlTB1.Text = GetCameraUrl();
        connectBtn1.Enabled = true;
        Log.Write("Camera1: Composed!");
      }


      void composeBtn2_Click(object sender, EventArgs e)
      {
        cameraUrlTB2.Text = GetCameraUrl();
        connectBtn2.Enabled = true;
        Log.Write("Camera2: Composed!");
      }

      void connectBtn1_Click(object sender, EventArgs e)
      {
        ci1.Initialize(cameraUrlTB1.Text);
        Log.Write("Camera1: connected!");
      }

      void connectBtn2_Click(object sender, EventArgs e)
      {
        ci2.Initialize(cameraUrlTB2.Text);
        Log.Write("Camera2: connected!");
      }


      void disconnectBtn_Click(object sender, EventArgs e)
      {
        ci1.CancelRecording();
        ci1.Disconnect();
        Log.Write("Camera1: disconnected!");
      }

      void disconnectBtn2_Click(object sender, EventArgs e)
      {
        ci2.CancelRecording();
        ci2.Disconnect();
        Log.Write("Camera2: disconnected!");
      }

      void startRecordingBtn1_Click(object sender, EventArgs e)
      {
        ci1.StartRecording();
        startRecordingBTN1.Enabled = false;
        stopRecordingBTN1.Enabled = true;
        Log.Write("Camera1: Recording started!");
      }

      void StartRecordingBTN2_Click(object sender, EventArgs e)
      {
        ci2.StartRecording();
        startRecordingBTN2.Enabled = false;
        stopRecordingBTN2.Enabled = true;
        Log.Write("Camera2: Recording started!");
      }

      void stopRecordingBtn1_Click(object sender, EventArgs e)
      {
        ci1.CancelRecording();
        Log.Write("Camera1: Recording stopped!");
      }


      void StopRecordingBtn2_Click(object sender, EventArgs e)
      {
        ci2.CancelRecording();
        Log.Write("Camera2: Recording stopped!");
      }
    #endregion



      void InvokeGuiThread(Action action)
      {
        BeginInvoke(action);
      }

      void browseSaveToDirBtn1_Click(object sender, EventArgs e)
      {
        if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
        {
          saveToDirTb1.Text = folderBrowserDialog1.SelectedPath;
          Settings.SaveToDirectory = folderBrowserDialog1.SelectedPath;
          Log.Write("Settings: Output directory changed! New value: " + Settings.SaveToDirectory.ToString());
        }
      }

      void ChangeRecordingStatus(Label label, string status)
      {
        InvokeGuiThread(() => { label.Text = status; }); 
      }

    #region Full screen handling
      bool isFullScreen = false;

      void videoViewerWF1_DoubleClick(object sender, EventArgs e)
      {
        if (isFullScreen)
          videoViewerWF1.FullScreenLeave();
        else
          videoViewerWF1.FullScreenEnter();
      }

      void videoViewerWF1_FullScreenEnterEvent(object sender, EventArgs e)
      {
        isFullScreen = true;
      }

      void videoViewerWF1_FullScreenLeaveEvent(object sender, EventArgs e)
      {
        isFullScreen = false;
      }
    #endregion

    void recordingOnMotionCB_CheckedChanged(object sender, EventArgs e)
    {
      var cb = sender as CheckBox;
      Settings.RecordOnMotion = cb.Checked;
      minVideoLength.Enabled = cb.Checked ? true : false;
      Log.Write("Settings: Record on motion changed! New value: " + Settings.RecordOnMotion.ToString());
    }

    void videoLength_TextChanged(object sender, EventArgs e)
    {
      Settings.MinVideoLength = Int32.Parse(minVideoLength.Text);
      Log.Write("Settings: Min video length on motion changed! New value: " + Settings.MinVideoLength);
    }

    void maxVideoLength_TextChanged(object sender, EventArgs e)
    {
      Settings.MaxVideoLength = Int32.Parse(maxVideoLength.Text);
      Log.Write("Settings: Max video length on motion changed! New value: " + Settings.MaxVideoLength);
    }

    void saveLogBtn_Click(object sender, EventArgs e)
    {
      //const string sPath = "save.txt";

      SaveFileDialog saveFileDialog1 = new SaveFileDialog();
      saveFileDialog1.Filter = "log files (*.log)|*.log|All files (*.*)|*.*";
      saveFileDialog1.FilterIndex = 2;
      saveFileDialog1.RestoreDirectory = true;
      saveFileDialog1.FileName = Log.fileName;

      if (saveFileDialog1.ShowDialog() == DialogResult.OK)
       saveLogTo(saveFileDialog1.FileName);
    }

    void saveLogTo(string FileName)
    {
      try
      {
        StreamWriter SaveFile = new StreamWriter(FileName);
        foreach (var item in logListBox.Items)
          SaveFile.WriteLine(item);

        SaveFile.Close();
        //MessageBox.Show("Log successfully saved to " + FileName);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString());
      }
    }

		void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			var cb = sender as CheckBox;
			if (cb.Checked)
				videoViewerWF1.Start();
			else
				videoViewerWF1.Stop();

			Settings.VideoViewer1Visible = cb.Checked;
    }
	}
}
