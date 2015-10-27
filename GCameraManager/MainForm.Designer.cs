namespace GCameraManager
{
    partial class MotionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.videoViewerWF1 = new Ozeki.Media.Video.Controls.VideoViewerWF();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.viewCameraCb1 = new System.Windows.Forms.CheckBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.cameraStateLB1 = new System.Windows.Forms.Label();
			this.disconnectBtn1 = new System.Windows.Forms.Button();
			this.connectBtn1 = new System.Windows.Forms.Button();
			this.composeBtn1 = new System.Windows.Forms.Button();
			this.cameraUrlTB1 = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.maxVideoLength = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.minVideoLength = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.pixelAmountSensitivity = new System.Windows.Forms.TextBox();
			this.pixelIntensitySensitivity = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.recordingSettingsGB1 = new System.Windows.Forms.GroupBox();
			this.browseSaveToDirBtn1 = new System.Windows.Forms.Button();
			this.saveToDirLb1 = new System.Windows.Forms.Label();
			this.saveToDirTb1 = new System.Windows.Forms.TextBox();
			this.recordingOnMotionCB = new System.Windows.Forms.CheckBox();
			this.stopRecordingBTN1 = new System.Windows.Forms.Button();
			this.startRecordingBTN1 = new System.Windows.Forms.Button();
			this.recordingStatusLB1 = new System.Windows.Forms.Label();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.recordingButtonsGB1 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.recordingButtonsGB2 = new System.Windows.Forms.GroupBox();
			this.startRecordingBTN2 = new System.Windows.Forms.Button();
			this.recordingStatusLB2 = new System.Windows.Forms.Label();
			this.stopRecordingBTN2 = new System.Windows.Forms.Button();
			this.videoViewerWF2 = new Ozeki.Media.Video.Controls.VideoViewerWF();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.viewCameraCb2 = new System.Windows.Forms.CheckBox();
			this.cameraStateLB2 = new System.Windows.Forms.Label();
			this.disconnectBtn2 = new System.Windows.Forms.Button();
			this.connectBtn2 = new System.Windows.Forms.Button();
			this.composeBtn2 = new System.Windows.Forms.Button();
			this.cameraUrlTB2 = new System.Windows.Forms.TextBox();
			this.eventsLogGB = new System.Windows.Forms.GroupBox();
			this.logListBox = new System.Windows.Forms.ListBox();
			this.saveLogBtn = new System.Windows.Forms.Button();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.saveLogOnExitCb = new System.Windows.Forms.CheckBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.recordingSettingsGB1.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.recordingButtonsGB1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.recordingButtonsGB2.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.eventsLogGB.SuspendLayout();
			this.SuspendLayout();
			// 
			// videoViewerWF1
			// 
			this.videoViewerWF1.BackColor = System.Drawing.Color.Black;
			this.videoViewerWF1.FlipMode = Ozeki.Media.Video.FlipMode.None;
			this.videoViewerWF1.FrameStretch = Ozeki.Media.Video.Controls.FrameStretch.Uniform;
			this.videoViewerWF1.FullScreenEnabled = true;
			this.videoViewerWF1.Location = new System.Drawing.Point(12, 172);
			this.videoViewerWF1.Name = "videoViewerWF1";
			this.videoViewerWF1.RotateAngle = 0;
			this.videoViewerWF1.Size = new System.Drawing.Size(368, 263);
			this.videoViewerWF1.TabIndex = 0;
			this.videoViewerWF1.Text = "9";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.viewCameraCb1);
			this.groupBox1.Controls.Add(this.comboBox1);
			this.groupBox1.Controls.Add(this.cameraStateLB1);
			this.groupBox1.Controls.Add(this.disconnectBtn1);
			this.groupBox1.Controls.Add(this.connectBtn1);
			this.groupBox1.Controls.Add(this.composeBtn1);
			this.groupBox1.Controls.Add(this.cameraUrlTB1);
			this.groupBox1.Location = new System.Drawing.Point(6, 19);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(374, 98);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Connection url";
			// 
			// viewCameraCb1
			// 
			this.viewCameraCb1.AutoSize = true;
			this.viewCameraCb1.Checked = true;
			this.viewCameraCb1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.viewCameraCb1.Location = new System.Drawing.Point(279, 50);
			this.viewCameraCb1.Name = "viewCameraCb1";
			this.viewCameraCb1.Size = new System.Drawing.Size(89, 17);
			this.viewCameraCb1.TabIndex = 12;
			this.viewCameraCb1.Text = "Display video";
			this.viewCameraCb1.UseVisualStyleBackColor = true;
			this.viewCameraCb1.CheckedChanged += new System.EventHandler(this.viewCamera_ci1_CheckedChanged);
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(6, 74);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 21);
			this.comboBox1.TabIndex = 12;
			// 
			// cameraStateLB1
			// 
			this.cameraStateLB1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cameraStateLB1.ForeColor = System.Drawing.Color.Red;
			this.cameraStateLB1.Location = new System.Drawing.Point(171, 50);
			this.cameraStateLB1.Name = "cameraStateLB1";
			this.cameraStateLB1.Size = new System.Drawing.Size(81, 14);
			this.cameraStateLB1.TabIndex = 5;
			this.cameraStateLB1.Text = "Disconnected";
			// 
			// disconnectBtn1
			// 
			this.disconnectBtn1.Location = new System.Drawing.Point(90, 45);
			this.disconnectBtn1.Name = "disconnectBtn1";
			this.disconnectBtn1.Size = new System.Drawing.Size(75, 23);
			this.disconnectBtn1.TabIndex = 4;
			this.disconnectBtn1.Text = "Disconnect";
			this.disconnectBtn1.UseVisualStyleBackColor = true;
			this.disconnectBtn1.Click += new System.EventHandler(this.disconnectBtn_Click);
			// 
			// connectBtn1
			// 
			this.connectBtn1.Location = new System.Drawing.Point(6, 45);
			this.connectBtn1.Name = "connectBtn1";
			this.connectBtn1.Size = new System.Drawing.Size(75, 23);
			this.connectBtn1.TabIndex = 3;
			this.connectBtn1.Text = "Connect";
			this.connectBtn1.UseVisualStyleBackColor = true;
			this.connectBtn1.Click += new System.EventHandler(this.connectBtn1_Click);
			// 
			// composeBtn1
			// 
			this.composeBtn1.Location = new System.Drawing.Point(293, 18);
			this.composeBtn1.Name = "composeBtn1";
			this.composeBtn1.Size = new System.Drawing.Size(75, 23);
			this.composeBtn1.TabIndex = 2;
			this.composeBtn1.Text = "Compose";
			this.composeBtn1.UseVisualStyleBackColor = true;
			this.composeBtn1.Click += new System.EventHandler(this.composeBtn1_Click);
			// 
			// cameraUrlTB1
			// 
			this.cameraUrlTB1.Location = new System.Drawing.Point(6, 19);
			this.cameraUrlTB1.Name = "cameraUrlTB1";
			this.cameraUrlTB1.Size = new System.Drawing.Size(281, 20);
			this.cameraUrlTB1.TabIndex = 1;
			this.cameraUrlTB1.Text = "usb://DeviceId=0;Name=HP HD Webcam [Fixed];";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.maxVideoLength);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.minVideoLength);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.pixelAmountSensitivity);
			this.groupBox2.Controls.Add(this.pixelIntensitySensitivity);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Location = new System.Drawing.Point(6, 153);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(232, 151);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Motion detection";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(163, 79);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(47, 13);
			this.label4.TabIndex = 18;
			this.label4.Text = "seconds";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(163, 105);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(47, 13);
			this.label7.TabIndex = 19;
			this.label7.Text = "seconds";
			// 
			// maxVideoLength
			// 
			this.maxVideoLength.Location = new System.Drawing.Point(127, 102);
			this.maxVideoLength.Name = "maxVideoLength";
			this.maxVideoLength.Size = new System.Drawing.Size(30, 20);
			this.maxVideoLength.TabIndex = 17;
			this.maxVideoLength.Text = "15";
			this.maxVideoLength.TextChanged += new System.EventHandler(this.maxVideoLength_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 105);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(109, 13);
			this.label1.TabIndex = 16;
			this.label1.Text = "Max recording length:";
			// 
			// minVideoLength
			// 
			this.minVideoLength.Location = new System.Drawing.Point(127, 76);
			this.minVideoLength.Name = "minVideoLength";
			this.minVideoLength.Size = new System.Drawing.Size(30, 20);
			this.minVideoLength.TabIndex = 15;
			this.minVideoLength.Text = "5";
			this.minVideoLength.TextChanged += new System.EventHandler(this.videoLength_TextChanged);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(6, 79);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(106, 13);
			this.label10.TabIndex = 14;
			this.label10.Text = "Min recording length:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(163, 53);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(40, 13);
			this.label6.TabIndex = 7;
			this.label6.Text = "(0-255)";
			this.toolTip1.SetToolTip(this.label6, "The lower the value the more sensitive the motion detector will be because it wil" +
        "l react to a lower amount of pixel colour changes");
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(163, 27);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(15, 13);
			this.label5.TabIndex = 6;
			this.label5.Text = "%";
			this.toolTip1.SetToolTip(this.label5, "The lower the value the more sensitive the motion detector will be because it wil" +
        "l react to a lower number of pixel changes as well.");
			// 
			// pixelAmountSensitivity
			// 
			this.pixelAmountSensitivity.Location = new System.Drawing.Point(127, 50);
			this.pixelAmountSensitivity.Name = "pixelAmountSensitivity";
			this.pixelAmountSensitivity.Size = new System.Drawing.Size(30, 20);
			this.pixelAmountSensitivity.TabIndex = 4;
			this.pixelAmountSensitivity.Text = "50";
			this.toolTip1.SetToolTip(this.pixelAmountSensitivity, "The lower the value the more sensitive the motion detector will be because it wil" +
        "l react to a lower amount of pixel colour changes");
			// 
			// pixelIntensitySensitivity
			// 
			this.pixelIntensitySensitivity.Location = new System.Drawing.Point(127, 24);
			this.pixelIntensitySensitivity.Name = "pixelIntensitySensitivity";
			this.pixelIntensitySensitivity.Size = new System.Drawing.Size(30, 20);
			this.pixelIntensitySensitivity.TabIndex = 3;
			this.pixelIntensitySensitivity.Text = "5";
			this.toolTip1.SetToolTip(this.pixelIntensitySensitivity, "The lower the value the more sensitive the motion detector will be because it wil" +
        "l react to a lower number of pixel changes as well.");
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 53);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(118, 13);
			this.label3.TabIndex = 1;
			this.label3.Text = "Pixel intensity sensitivity";
			this.toolTip1.SetToolTip(this.label3, "The lower the value the more sensitive the motion detector will be because it wil" +
        "l react to a lower amount of pixel colour changes");
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 27);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(115, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Pixel amount sensitivity";
			this.toolTip1.SetToolTip(this.label2, "The lower the value the more sensitive the motion detector will be because it wil" +
        "l react to a lower number of pixel changes as well.");
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.groupBox2);
			this.groupBox4.Controls.Add(this.recordingSettingsGB1);
			this.groupBox4.Location = new System.Drawing.Point(12, 12);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(243, 420);
			this.groupBox4.TabIndex = 7;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Settings";
			// 
			// recordingSettingsGB1
			// 
			this.recordingSettingsGB1.Controls.Add(this.browseSaveToDirBtn1);
			this.recordingSettingsGB1.Controls.Add(this.saveToDirLb1);
			this.recordingSettingsGB1.Controls.Add(this.saveToDirTb1);
			this.recordingSettingsGB1.Controls.Add(this.recordingOnMotionCB);
			this.recordingSettingsGB1.Location = new System.Drawing.Point(6, 19);
			this.recordingSettingsGB1.Name = "recordingSettingsGB1";
			this.recordingSettingsGB1.Size = new System.Drawing.Size(232, 128);
			this.recordingSettingsGB1.TabIndex = 9;
			this.recordingSettingsGB1.TabStop = false;
			this.recordingSettingsGB1.Text = "Recording";
			// 
			// browseSaveToDirBtn1
			// 
			this.browseSaveToDirBtn1.Location = new System.Drawing.Point(163, 88);
			this.browseSaveToDirBtn1.Name = "browseSaveToDirBtn1";
			this.browseSaveToDirBtn1.Size = new System.Drawing.Size(60, 23);
			this.browseSaveToDirBtn1.TabIndex = 12;
			this.browseSaveToDirBtn1.Text = "Browse";
			this.browseSaveToDirBtn1.UseVisualStyleBackColor = true;
			this.browseSaveToDirBtn1.Click += new System.EventHandler(this.browseSaveToDirBtn1_Click);
			// 
			// saveToDirLb1
			// 
			this.saveToDirLb1.AutoSize = true;
			this.saveToDirLb1.Location = new System.Drawing.Point(6, 72);
			this.saveToDirLb1.Name = "saveToDirLb1";
			this.saveToDirLb1.Size = new System.Drawing.Size(90, 13);
			this.saveToDirLb1.TabIndex = 11;
			this.saveToDirLb1.Text = "Save to directory:";
			// 
			// saveToDirTb1
			// 
			this.saveToDirTb1.Location = new System.Drawing.Point(6, 88);
			this.saveToDirTb1.Name = "saveToDirTb1";
			this.saveToDirTb1.Size = new System.Drawing.Size(151, 20);
			this.saveToDirTb1.TabIndex = 10;
			this.saveToDirTb1.Text = "C:\\Video Backup";
			// 
			// recordingOnMotionCB
			// 
			this.recordingOnMotionCB.AutoSize = true;
			this.recordingOnMotionCB.Checked = true;
			this.recordingOnMotionCB.CheckState = System.Windows.Forms.CheckState.Checked;
			this.recordingOnMotionCB.Location = new System.Drawing.Point(9, 19);
			this.recordingOnMotionCB.Name = "recordingOnMotionCB";
			this.recordingOnMotionCB.Size = new System.Drawing.Size(213, 17);
			this.recordingOnMotionCB.TabIndex = 9;
			this.recordingOnMotionCB.Text = "Start recording only on motion detection";
			this.recordingOnMotionCB.UseVisualStyleBackColor = true;
			this.recordingOnMotionCB.CheckedChanged += new System.EventHandler(this.recordingOnMotionCB_CheckedChanged);
			// 
			// stopRecordingBTN1
			// 
			this.stopRecordingBTN1.Enabled = false;
			this.stopRecordingBTN1.Location = new System.Drawing.Point(74, 19);
			this.stopRecordingBTN1.Name = "stopRecordingBTN1";
			this.stopRecordingBTN1.Size = new System.Drawing.Size(62, 23);
			this.stopRecordingBTN1.TabIndex = 7;
			this.stopRecordingBTN1.Text = "Stop";
			this.stopRecordingBTN1.UseVisualStyleBackColor = true;
			this.stopRecordingBTN1.Click += new System.EventHandler(this.stopRecordingBtn1_Click);
			// 
			// startRecordingBTN1
			// 
			this.startRecordingBTN1.Location = new System.Drawing.Point(6, 19);
			this.startRecordingBTN1.Name = "startRecordingBTN1";
			this.startRecordingBTN1.Size = new System.Drawing.Size(62, 23);
			this.startRecordingBTN1.TabIndex = 6;
			this.startRecordingBTN1.Text = "Start";
			this.startRecordingBTN1.UseVisualStyleBackColor = true;
			this.startRecordingBTN1.Click += new System.EventHandler(this.startRecordingBtn1_Click);
			// 
			// recordingStatusLB1
			// 
			this.recordingStatusLB1.Location = new System.Drawing.Point(268, 16);
			this.recordingStatusLB1.Name = "recordingStatusLB1";
			this.recordingStatusLB1.Size = new System.Drawing.Size(100, 23);
			this.recordingStatusLB1.TabIndex = 13;
			this.recordingStatusLB1.Text = "Stopped";
			this.recordingStatusLB1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.recordingButtonsGB1);
			this.groupBox5.Controls.Add(this.videoViewerWF1);
			this.groupBox5.Controls.Add(this.groupBox1);
			this.groupBox5.Location = new System.Drawing.Point(261, 12);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(389, 469);
			this.groupBox5.TabIndex = 10;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Camera 1:";
			// 
			// recordingButtonsGB1
			// 
			this.recordingButtonsGB1.Controls.Add(this.startRecordingBTN1);
			this.recordingButtonsGB1.Controls.Add(this.recordingStatusLB1);
			this.recordingButtonsGB1.Controls.Add(this.stopRecordingBTN1);
			this.recordingButtonsGB1.Enabled = false;
			this.recordingButtonsGB1.Location = new System.Drawing.Point(6, 120);
			this.recordingButtonsGB1.Name = "recordingButtonsGB1";
			this.recordingButtonsGB1.Size = new System.Drawing.Size(374, 46);
			this.recordingButtonsGB1.TabIndex = 11;
			this.recordingButtonsGB1.TabStop = false;
			this.recordingButtonsGB1.Text = "Recording:";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.recordingButtonsGB2);
			this.groupBox3.Controls.Add(this.videoViewerWF2);
			this.groupBox3.Controls.Add(this.groupBox7);
			this.groupBox3.Location = new System.Drawing.Point(656, 12);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(389, 490);
			this.groupBox3.TabIndex = 12;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Camera 2:";
			// 
			// recordingButtonsGB2
			// 
			this.recordingButtonsGB2.Controls.Add(this.startRecordingBTN2);
			this.recordingButtonsGB2.Controls.Add(this.recordingStatusLB2);
			this.recordingButtonsGB2.Controls.Add(this.stopRecordingBTN2);
			this.recordingButtonsGB2.Enabled = false;
			this.recordingButtonsGB2.Location = new System.Drawing.Point(6, 118);
			this.recordingButtonsGB2.Name = "recordingButtonsGB2";
			this.recordingButtonsGB2.Size = new System.Drawing.Size(374, 46);
			this.recordingButtonsGB2.TabIndex = 11;
			this.recordingButtonsGB2.TabStop = false;
			this.recordingButtonsGB2.Text = "Recording:";
			// 
			// startRecordingBTN2
			// 
			this.startRecordingBTN2.Location = new System.Drawing.Point(6, 19);
			this.startRecordingBTN2.Name = "startRecordingBTN2";
			this.startRecordingBTN2.Size = new System.Drawing.Size(62, 23);
			this.startRecordingBTN2.TabIndex = 6;
			this.startRecordingBTN2.Text = "Start";
			this.startRecordingBTN2.UseVisualStyleBackColor = true;
			this.startRecordingBTN2.Click += new System.EventHandler(this.StartRecordingBTN2_Click);
			// 
			// recordingStatusLB2
			// 
			this.recordingStatusLB2.Location = new System.Drawing.Point(268, 16);
			this.recordingStatusLB2.Name = "recordingStatusLB2";
			this.recordingStatusLB2.Size = new System.Drawing.Size(100, 23);
			this.recordingStatusLB2.TabIndex = 13;
			this.recordingStatusLB2.Text = "Stopped";
			this.recordingStatusLB2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// stopRecordingBTN2
			// 
			this.stopRecordingBTN2.Enabled = false;
			this.stopRecordingBTN2.Location = new System.Drawing.Point(74, 19);
			this.stopRecordingBTN2.Name = "stopRecordingBTN2";
			this.stopRecordingBTN2.Size = new System.Drawing.Size(62, 23);
			this.stopRecordingBTN2.TabIndex = 7;
			this.stopRecordingBTN2.Text = "Stop";
			this.stopRecordingBTN2.UseVisualStyleBackColor = true;
			this.stopRecordingBTN2.Click += new System.EventHandler(this.StopRecordingBtn2_Click);
			// 
			// videoViewerWF2
			// 
			this.videoViewerWF2.BackColor = System.Drawing.Color.Black;
			this.videoViewerWF2.FlipMode = Ozeki.Media.Video.FlipMode.None;
			this.videoViewerWF2.FrameStretch = Ozeki.Media.Video.Controls.FrameStretch.Uniform;
			this.videoViewerWF2.FullScreenEnabled = true;
			this.videoViewerWF2.Location = new System.Drawing.Point(6, 172);
			this.videoViewerWF2.Name = "videoViewerWF2";
			this.videoViewerWF2.RotateAngle = 0;
			this.videoViewerWF2.Size = new System.Drawing.Size(368, 263);
			this.videoViewerWF2.TabIndex = 0;
			this.videoViewerWF2.Text = "videoViewerWF2";
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.viewCameraCb2);
			this.groupBox7.Controls.Add(this.cameraStateLB2);
			this.groupBox7.Controls.Add(this.disconnectBtn2);
			this.groupBox7.Controls.Add(this.connectBtn2);
			this.groupBox7.Controls.Add(this.composeBtn2);
			this.groupBox7.Controls.Add(this.cameraUrlTB2);
			this.groupBox7.Location = new System.Drawing.Point(6, 19);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(374, 81);
			this.groupBox7.TabIndex = 1;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Connection url";
			// 
			// viewCameraCb2
			// 
			this.viewCameraCb2.AutoSize = true;
			this.viewCameraCb2.Checked = true;
			this.viewCameraCb2.CheckState = System.Windows.Forms.CheckState.Checked;
			this.viewCameraCb2.Location = new System.Drawing.Point(279, 49);
			this.viewCameraCb2.Name = "viewCameraCb2";
			this.viewCameraCb2.Size = new System.Drawing.Size(89, 17);
			this.viewCameraCb2.TabIndex = 13;
			this.viewCameraCb2.Text = "Display video";
			this.viewCameraCb2.UseVisualStyleBackColor = true;
			this.viewCameraCb2.CheckedChanged += new System.EventHandler(this.viewCamera_ci2_CheckedChanged);
			// 
			// cameraStateLB2
			// 
			this.cameraStateLB2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cameraStateLB2.ForeColor = System.Drawing.Color.Red;
			this.cameraStateLB2.Location = new System.Drawing.Point(171, 50);
			this.cameraStateLB2.Name = "cameraStateLB2";
			this.cameraStateLB2.Size = new System.Drawing.Size(81, 14);
			this.cameraStateLB2.TabIndex = 5;
			this.cameraStateLB2.Text = "Disconnected";
			// 
			// disconnectBtn2
			// 
			this.disconnectBtn2.Location = new System.Drawing.Point(90, 45);
			this.disconnectBtn2.Name = "disconnectBtn2";
			this.disconnectBtn2.Size = new System.Drawing.Size(75, 23);
			this.disconnectBtn2.TabIndex = 4;
			this.disconnectBtn2.Text = "Disconnect";
			this.disconnectBtn2.UseVisualStyleBackColor = true;
			this.disconnectBtn2.Click += new System.EventHandler(this.disconnectBtn2_Click);
			// 
			// connectBtn2
			// 
			this.connectBtn2.Location = new System.Drawing.Point(6, 45);
			this.connectBtn2.Name = "connectBtn2";
			this.connectBtn2.Size = new System.Drawing.Size(75, 23);
			this.connectBtn2.TabIndex = 3;
			this.connectBtn2.Text = "Connect";
			this.connectBtn2.UseVisualStyleBackColor = true;
			this.connectBtn2.Click += new System.EventHandler(this.connectBtn2_Click);
			// 
			// composeBtn2
			// 
			this.composeBtn2.Location = new System.Drawing.Point(293, 18);
			this.composeBtn2.Name = "composeBtn2";
			this.composeBtn2.Size = new System.Drawing.Size(75, 23);
			this.composeBtn2.TabIndex = 2;
			this.composeBtn2.Text = "Compose";
			this.composeBtn2.UseVisualStyleBackColor = true;
			this.composeBtn2.Click += new System.EventHandler(this.composeBtn2_Click);
			// 
			// cameraUrlTB2
			// 
			this.cameraUrlTB2.Location = new System.Drawing.Point(6, 19);
			this.cameraUrlTB2.Name = "cameraUrlTB2";
			this.cameraUrlTB2.Size = new System.Drawing.Size(281, 20);
			this.cameraUrlTB2.TabIndex = 1;
			this.cameraUrlTB2.Text = "usb://DeviceId=1;Name=HP Prem AF Webcam KQ245AA;";
			// 
			// eventsLogGB
			// 
			this.eventsLogGB.Controls.Add(this.logListBox);
			this.eventsLogGB.Location = new System.Drawing.Point(12, 485);
			this.eventsLogGB.Name = "eventsLogGB";
			this.eventsLogGB.Size = new System.Drawing.Size(1018, 229);
			this.eventsLogGB.TabIndex = 13;
			this.eventsLogGB.TabStop = false;
			this.eventsLogGB.Text = "Events log";
			// 
			// logListBox
			// 
			this.logListBox.FormattingEnabled = true;
			this.logListBox.HorizontalScrollbar = true;
			this.logListBox.Location = new System.Drawing.Point(7, 20);
			this.logListBox.Name = "logListBox";
			this.logListBox.Size = new System.Drawing.Size(1006, 212);
			this.logListBox.TabIndex = 0;
			// 
			// saveLogBtn
			// 
			this.saveLogBtn.Location = new System.Drawing.Point(19, 723);
			this.saveLogBtn.Name = "saveLogBtn";
			this.saveLogBtn.Size = new System.Drawing.Size(75, 23);
			this.saveLogBtn.TabIndex = 14;
			this.saveLogBtn.Text = "Save log";
			this.saveLogBtn.UseVisualStyleBackColor = true;
			this.saveLogBtn.Click += new System.EventHandler(this.saveLogBtn_Click);
			// 
			// saveLogOnExitCb
			// 
			this.saveLogOnExitCb.AutoSize = true;
			this.saveLogOnExitCb.Checked = true;
			this.saveLogOnExitCb.CheckState = System.Windows.Forms.CheckState.Checked;
			this.saveLogOnExitCb.Location = new System.Drawing.Point(101, 727);
			this.saveLogOnExitCb.Name = "saveLogOnExitCb";
			this.saveLogOnExitCb.Size = new System.Drawing.Size(102, 17);
			this.saveLogOnExitCb.TabIndex = 15;
			this.saveLogOnExitCb.Text = "Save log on exit";
			this.saveLogOnExitCb.UseVisualStyleBackColor = true;
			// 
			// MotionForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1151, 774);
			this.Controls.Add(this.saveLogOnExitCb);
			this.Controls.Add(this.saveLogBtn);
			this.Controls.Add(this.eventsLogGB);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.groupBox4);
			this.Name = "MotionForm";
			this.Text = "Motion Detection";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MotionForm_Closing);
			this.Load += new System.EventHandler(this.MotionForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.recordingSettingsGB1.ResumeLayout(false);
			this.recordingSettingsGB1.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.recordingButtonsGB1.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.recordingButtonsGB2.ResumeLayout(false);
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			this.eventsLogGB.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private Ozeki.Media.Video.Controls.VideoViewerWF videoViewerWF1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button composeBtn1;
        private System.Windows.Forms.TextBox cameraUrlTB1;
        private System.Windows.Forms.Button disconnectBtn1;
        private System.Windows.Forms.Button connectBtn1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox pixelAmountSensitivity;
        private System.Windows.Forms.TextBox pixelIntensitySensitivity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label cameraStateLB1;
        private System.Windows.Forms.Button stopRecordingBTN1;
        private System.Windows.Forms.CheckBox recordingOnMotionCB;
        private System.Windows.Forms.Button startRecordingBTN1;
        private System.Windows.Forms.TextBox saveToDirTb1;
        private System.Windows.Forms.Label saveToDirLb1;
        private System.Windows.Forms.GroupBox recordingSettingsGB1;
        private System.Windows.Forms.Button browseSaveToDirBtn1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label recordingStatusLB1;
        private System.Windows.Forms.TextBox minVideoLength;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox recordingButtonsGB1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox recordingButtonsGB2;
        private System.Windows.Forms.Button startRecordingBTN2;
        private System.Windows.Forms.Label recordingStatusLB2;
        private System.Windows.Forms.Button stopRecordingBTN2;
        private Ozeki.Media.Video.Controls.VideoViewerWF videoViewerWF2;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label cameraStateLB2;
        private System.Windows.Forms.Button disconnectBtn2;
        private System.Windows.Forms.Button connectBtn2;
        private System.Windows.Forms.Button composeBtn2;
        private System.Windows.Forms.TextBox cameraUrlTB2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox eventsLogGB;
        private System.Windows.Forms.ListBox logListBox;
        private System.Windows.Forms.Button saveLogBtn;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.CheckBox saveLogOnExitCb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox maxVideoLength;
        private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.CheckBox viewCameraCb1;
		private System.Windows.Forms.CheckBox viewCameraCb2;
	}
}

