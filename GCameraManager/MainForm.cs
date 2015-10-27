using Ozeki.Camera.Data;
using Ozeki.Media.Video.Controls;
using System;
using System.IO;
using System.Windows.Forms;

namespace GCameraManager
{
  public partial class MotionForm : Form
  {
    CameraConfigurationItem cci1;
    CameraConfigurationItem cci2;

    CameraURLBuilderWF cameraUrlBuilder;

    public MotionForm()
    {
      //this.FormClosing += MotionForm_Closing;
      InitializeComponent();
      Log.OnLogMessageReceived += Log_OnLogMessageReceived;

      cci1 = new CameraConfigurationItem("1", videoViewerWF1);
      cci1.CameraStateChanged += OnCameraStateChanged;
      cci1.VideoCapturingStateChanged += OnVideoCapturingStateChanged;
			cci1.VideoViewerVisible = viewCameraCb1.Checked;

      cci2 = new CameraConfigurationItem("2", videoViewerWF2);
      cci2.CameraStateChanged += OnCameraStateChanged;
      cci2.VideoCapturingStateChanged += OnVideoCapturingStateChanged;
			cci2.VideoViewerVisible = viewCameraCb2.Checked;

			var data = new CameraURLBuilderData { IPCameraEnabled = false };
      cameraUrlBuilder = new CameraURLBuilderWF(data);
    }

    #region Events handling

    #region Form events
    void MotionForm_Load(object sender, EventArgs e)
    {
      Log.Write("GCameraManager started! Form loaded!");

			//Set settings
			SaveSettings();

      if (!IsValidCameraUrl(cameraUrlTB1.Text))
        connectBtn1.Enabled = false;
      else
      {
        disconnectBtn1.Enabled = false;
        //If connect on startup is enabled
        if (CmdArguments.IsAutoConnect(cci1))
          cci1.Connect(cameraUrlTB1.Text);
      }

      if (!IsValidCameraUrl(cameraUrlTB2.Text))
        connectBtn2.Enabled = false;
			else
			{ 
				disconnectBtn2.Enabled = false;
				//If connect on startup is enabled
				if (CmdArguments.IsAutoConnect(cci2))
					cci2.Connect(cameraUrlTB2.Text);
			}
		}

		void SaveSettings()
		{
			Settings.SaveToDirectory = saveToDirTb1.Text;
			Settings.RecordOnMotion = recordingOnMotionCB.Checked;
			Settings.MinVideoLength = Int32.Parse(minVideoLength.Text);
			Settings.PixelIntensitySensitivity = Int32.Parse(pixelIntensitySensitivity.Text);
			Settings.PixelAmountSensitivity = Int32.Parse(pixelAmountSensitivity.Text);
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
        //If Save log file is enabled
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

		#region Handle Camera Events

		/// <summary>
		/// Handler for the CameraStateChanged event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnCameraStateChanged(object sender, CameraStateEventArgs e)
		{
			var cci = sender as CameraConfigurationItem;
			var connectBtn = this.Controls.Find("connectBtn" + cci.id, true)[0] as Button;
			var disconnectBtn = this.Controls.Find("disconnectBtn" + cci.id, true)[0] as Button;
			var composeBtn = this.Controls.Find("composeBtn" + cci.id, true)[0] as Button;
			var recordingButtons = this.Controls.Find("recordingButtonsGB" + cci.id, true)[0] as GroupBox;
			var cameraUrl = this.Controls.Find("cameraUrlTB" + cci.id, true)[0] as TextBox;
			var cameraState = this.Controls.Find("cameraStateLB" + cci.id, true)[0] as Label;

			InvokeGuiThread(() =>
			{
				switch (e.State)
				{
					case CameraState.Streaming:
						disconnectBtn.Enabled = true;
						connectBtn.Enabled = false;
						//recordingSettingsGB1.Enabled = true;
						composeBtn.Enabled = false;
						cameraUrl.Enabled = false;
						cameraState.ForeColor = System.Drawing.Color.Green;
						recordingButtons.Enabled = true;
						break;
					case CameraState.Disconnected:
						disconnectBtn.Enabled = false;
						connectBtn.Enabled = true;
						composeBtn.Enabled = true;
						cameraUrl.Enabled = true;
						cameraState.ForeColor = System.Drawing.Color.Red;
						//recordingSettingsGB1.Enabled = false;
						recordingButtons.Enabled = false;
						break;
					case CameraState.Connected:
						connectBtn.Enabled = false;
						composeBtn.Enabled = false;
						disconnectBtn.Enabled = true;
						cameraUrl.Enabled = false;
						recordingButtons.Enabled = true;
						cameraState.ForeColor = System.Drawing.Color.Green;
						break;
					case CameraState.Error:
						connectBtn.Enabled = true;
						composeBtn.Enabled = true;
						cameraUrl.Enabled = true;
						cameraState.ForeColor = System.Drawing.Color.Red;
						//Log error
						break;
				}
			});
			ChangeRecordingStatus(cameraState, e.State.ToString());
			Log.Write("Camera" + cci.id + ": Recording status changed: " + e.State.ToString());
		}

		/*void camera_CameraErrorOccurred(object sender, CameraErrorEventArgs e)
		{
			InvokeGuiThread(() => Log.Write("Camera error: " + (e.Details ?? e.Error.ToString())));
		}*/

		/// <summary>
		/// Handler for the VideoCapturingStateChanged event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnVideoCapturingStateChanged(object sender, VideoCapturingEventArgs e)
    {
			var cci = sender as CameraConfigurationItem;
			var startRecordingBtn = this.Controls.Find("startRecordingBTN" + cci.id, true)[0] as Button;
			var stopRecordingBtn = this.Controls.Find("stopRecordingBTN" + cci.id, true)[0] as Button;
			var recordingStatusLB = this.Controls.Find("recordingStatusLB" + cci.id, true)[0] as Label;

      InvokeGuiThread(() =>
      {
        switch (e.CapturingState)
        {
          case VideoCapturingState.Recording:
            startRecordingBtn.Enabled = false;
						stopRecordingBtn.Enabled = true;
            break;
          case VideoCapturingState.Stopped:
						startRecordingBtn.Enabled = true;
						stopRecordingBtn.Enabled = false;
            break;
        }
      });
      ChangeRecordingStatus(recordingStatusLB, e.CapturingState.ToString());
      Log.Write("Camera" + cci.id + ": Capturing status changed: " + e.CapturingState.ToString());
    }


		#endregion

		#endregion

		bool IsValidCameraUrl(string url)
    {
      //TODO make a real check
      if (url.Length > 0)
        return true;
      return false;
    }

    #region Form buttons

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
        cci1.Connect(cameraUrlTB1.Text);
        Log.Write("Camera1: connected!");
      }

      void connectBtn2_Click(object sender, EventArgs e)
      {
        cci2.Connect(cameraUrlTB2.Text);
        Log.Write("Camera2: connected!");
      }


      void disconnectBtn_Click(object sender, EventArgs e)
      {
        cci1.CancelRecording();
        cci1.Disconnect();
        Log.Write("Camera1: disconnected!");
      }

      void disconnectBtn2_Click(object sender, EventArgs e)
      {
        cci2.CancelRecording();
        cci2.Disconnect();
        Log.Write("Camera2: disconnected!");
      }

      void startRecordingBtn1_Click(object sender, EventArgs e)
      {
        cci1.StartRecording();
        startRecordingBTN1.Enabled = false;
        stopRecordingBTN1.Enabled = true;
        Log.Write("Camera1: Recording started!");
      }

      void StartRecordingBTN2_Click(object sender, EventArgs e)
      {
        cci2.StartRecording();
        startRecordingBTN2.Enabled = false;
        stopRecordingBTN2.Enabled = true;
        Log.Write("Camera2: Recording started!");
      }

      void stopRecordingBtn1_Click(object sender, EventArgs e)
      {
        cci1.CancelRecording();
        Log.Write("Camera1: Recording stopped!");
      }
		
      void StopRecordingBtn2_Click(object sender, EventArgs e)
      {
        cci2.CancelRecording();
        Log.Write("Camera2: Recording stopped!");
      }
    

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

		#endregion

		#region Full screen handling
			/*bool isFullScreen = false;

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
      }*/
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

		void viewCamera_ci1_CheckedChanged(object sender, EventArgs e)
		{
			viewCamera_CheckedChanged(sender, cci1);
		}

		void viewCamera_ci2_CheckedChanged(object sender, EventArgs e)
		{
			viewCamera_CheckedChanged(sender, cci2);
    }

		void viewCamera_CheckedChanged(object sender, CameraConfigurationItem ci)
		{
			var cb = sender as CheckBox;
			ci.VideoViewerVisible = cb.Checked;
			if (ci.VideoViewerVisible)
				ci.videoViewer.Start();
			else
				ci.videoViewer.Stop();
		}
	}
}
