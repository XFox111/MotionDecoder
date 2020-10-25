namespace MotionDecoder.Forms
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.fileBrowser = new System.Windows.Forms.OpenFileDialog();
            this.treeView = new System.Windows.Forms.TreeView();
            this.label3 = new System.Windows.Forms.Label();
            this.helpToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.file = new System.Windows.Forms.ToolStripMenuItem();
            this.open = new System.Windows.Forms.ToolStripMenuItem();
            this.clear = new System.Windows.Forms.ToolStripMenuItem();
            this.about = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.videoPlayer = new MotionDecoder.VideoPlayer();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileBrowser
            // 
            this.fileBrowser.InitialDirectory = "%Desktop%";
            this.fileBrowser.Multiselect = true;
            // 
            // treeView
            // 
            resources.ApplyResources(this.treeView, "treeView");
            this.treeView.Name = "treeView";
            this.treeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.OnSegmentChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.file});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // file
            // 
            this.file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.open,
            this.clear,
            this.about});
            this.file.Name = "file";
            resources.ApplyResources(this.file, "file");
            // 
            // open
            // 
            this.open.Name = "open";
            resources.ApplyResources(this.open, "open");
            this.open.Click += new System.EventHandler(this.OpenFiles);
            // 
            // clear
            // 
            this.clear.Name = "clear";
            resources.ApplyResources(this.clear, "clear");
            this.clear.Click += new System.EventHandler(this.ClearView);
            // 
            // about
            // 
            this.about.Name = "about";
            resources.ApplyResources(this.about, "about");
            this.about.Click += new System.EventHandler(this.OpenAboutWindow);
            // 
            // comboBox
            // 
            resources.ApplyResources(this.comboBox, "comboBox");
            this.comboBox.DisplayMember = "0";
            this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Name = "comboBox";
            this.comboBox.SelectedIndexChanged += new System.EventHandler(this.OnVideoChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // videoPlayer
            // 
            resources.ApplyResources(this.videoPlayer, "videoPlayer");
            this.videoPlayer.Name = "videoPlayer";
            this.videoPlayer.NextSegmentRequested += new System.EventHandler(this.NextSegment);
            this.videoPlayer.PreviousSegmentRequested += new System.EventHandler(this.PreviousSegment);
            // 
            // Main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.videoPlayer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.menuStrip1);
            this.HelpButton = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKeyUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog fileBrowser;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip helpToolTip;
        private System.Windows.Forms.ToolStripMenuItem file;
        private System.Windows.Forms.ToolStripMenuItem open;
        private System.Windows.Forms.ToolStripMenuItem clear;
        private System.Windows.Forms.ToolStripMenuItem about;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Label label1;
        private VideoPlayer videoPlayer;
    }
}

