namespace MotionDecoder
{
    partial class VideoPlayer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoPlayer));
            this.timeCodeLabel = new System.Windows.Forms.Label();
            this.volumeBar = new System.Windows.Forms.TrackBar();
            this.stopBtn = new System.Windows.Forms.Button();
            this.playBtn = new System.Windows.Forms.Button();
            this.prevBtn = new System.Windows.Forms.Button();
            this.nextBtn = new System.Windows.Forms.Button();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cut = new System.Windows.Forms.CheckBox();
            this.outputFrame = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.volumeBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // timeCodeLabel
            // 
            resources.ApplyResources(this.timeCodeLabel, "timeCodeLabel");
            this.timeCodeLabel.Name = "timeCodeLabel";
            this.toolTip.SetToolTip(this.timeCodeLabel, resources.GetString("timeCodeLabel.ToolTip"));
            // 
            // volumeBar
            // 
            resources.ApplyResources(this.volumeBar, "volumeBar");
            this.volumeBar.Maximum = 0;
            this.volumeBar.Minimum = -3000;
            this.volumeBar.Name = "volumeBar";
            this.volumeBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toolTip.SetToolTip(this.volumeBar, resources.GetString("volumeBar.ToolTip"));
            this.volumeBar.Scroll += new System.EventHandler(this.VolumeChanged);
            // 
            // stopBtn
            // 
            resources.ApplyResources(this.stopBtn, "stopBtn");
            this.stopBtn.Name = "stopBtn";
            this.toolTip.SetToolTip(this.stopBtn, resources.GetString("stopBtn.ToolTip"));
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.StopClicked);
            // 
            // playBtn
            // 
            resources.ApplyResources(this.playBtn, "playBtn");
            this.playBtn.Name = "playBtn";
            this.toolTip.SetToolTip(this.playBtn, resources.GetString("playBtn.ToolTip"));
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.PlayClicked);
            // 
            // prevBtn
            // 
            resources.ApplyResources(this.prevBtn, "prevBtn");
            this.prevBtn.Name = "prevBtn";
            this.toolTip.SetToolTip(this.prevBtn, resources.GetString("prevBtn.ToolTip"));
            this.prevBtn.UseVisualStyleBackColor = true;
            this.prevBtn.Click += new System.EventHandler(this.PreviousClicked);
            // 
            // nextBtn
            // 
            resources.ApplyResources(this.nextBtn, "nextBtn");
            this.nextBtn.Name = "nextBtn";
            this.toolTip.SetToolTip(this.nextBtn, resources.GetString("nextBtn.ToolTip"));
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.NextClicked);
            // 
            // trackBar
            // 
            resources.ApplyResources(this.trackBar, "trackBar");
            this.trackBar.Name = "trackBar";
            this.trackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toolTip.SetToolTip(this.trackBar, resources.GetString("trackBar.ToolTip"));
            this.trackBar.MouseCaptureChanged += new System.EventHandler(this.SeekPositionChanged);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.TimerTicked);
            // 
            // cut
            // 
            resources.ApplyResources(this.cut, "cut");
            this.cut.Checked = true;
            this.cut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cut.Name = "cut";
            this.toolTip.SetToolTip(this.cut, resources.GetString("cut.ToolTip"));
            this.cut.UseVisualStyleBackColor = true;
            this.cut.CheckedChanged += new System.EventHandler(this.CutChanged);
            // 
            // outputFrame
            // 
            resources.ApplyResources(this.outputFrame, "outputFrame");
            this.outputFrame.BackColor = System.Drawing.Color.Black;
            this.outputFrame.Name = "outputFrame";
            // 
            // VideoPlayer
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.outputFrame);
            this.Controls.Add(this.cut);
            this.Controls.Add(this.timeCodeLabel);
            this.Controls.Add(this.volumeBar);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.playBtn);
            this.Controls.Add(this.prevBtn);
            this.Controls.Add(this.nextBtn);
            this.Controls.Add(this.trackBar);
            this.Name = "VideoPlayer";
            ((System.ComponentModel.ISupportInitialize)(this.volumeBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label timeCodeLabel;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.Button prevBtn;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolTip toolTip;
        public System.Windows.Forms.TrackBar trackBar;
        public System.Windows.Forms.CheckBox cut;
        public System.Windows.Forms.TrackBar volumeBar;
        private System.Windows.Forms.Panel outputFrame;
    }
}
