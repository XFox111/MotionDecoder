using System;
using System.Windows.Forms;
using MotionDecoder.Properties;
using MotionDecoder.Models;

namespace MotionDecoder.Forms
{
    public partial class Main : Form
    {
        Video[] collection = null;  // Collection of currently opened videos

        public Main()
        {
            InitializeComponent();
            
            fileBrowser.Filter = Settings.Default.filters;  // Settings file filters for picker
        }

        void OpenAboutWindow(object sender, EventArgs e)
        {
            About about = new About();
            about.Show(this);
            about.Dispose();
        }

        void ClearView(object sender, EventArgs e)
        {
            if (comboBox.Items.Count > 0 && MessageBox.Show(Resources.clearConf, Resources.questionHeader, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Clear();
        }

        void OpenFiles(object sender, EventArgs e)
        {
            if (Settings.Default.showMessage)   // Shows information about project capabilities issues
            {
                Settings.Default.showMessage = false;
                Settings.Default.Save();
                MessageBox.Show(Resources.attentionBody, Resources.attentionHead, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (fileBrowser.ShowDialog() == DialogResult.OK)
                ProcessFiles(fileBrowser.FileNames);
        }
        
        /// <summary>
        /// Clears menus, list, disposes instances etc
        /// </summary>
        void Clear()
        {
            comboBox.Enabled = false;
            comboBox.Items.Clear();
            treeView.Nodes.Clear();

            videoPlayer.Clear();
            collection = null;
            GC.Collect();
        }

        async void ProcessFiles(string[] paths)
        {
            Clear();
            Processing processingFrame = new Processing();
            processingFrame.Show(this);
            Enabled = false;
            collection = await processingFrame.ProcessAsync(paths);
            Enabled = true;
            processingFrame.Hide();
            processingFrame.Dispose();

            if (collection == null)
                return;

            foreach (Video video in collection)
                comboBox.Items.Add($"{video.Name} ({video.Markers.Count})");

            comboBox.Enabled = true;
            comboBox.SelectedIndex = 0;
        }

        void OnKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    videoPlayer.Play();
                    break;
                case Keys.Escape:
                    videoPlayer.Stop();
                    break;
                case Keys.Left:
                    PreviousSegment(this, null);
                    break;
                case Keys.Right:
                    NextSegment(this, null);
                    break;
                case Keys.Up:
                    videoPlayer.IncrementVolume();
                    break;
                case Keys.Down:
                    videoPlayer.DecrementVolume();
                    break;
            }
        }

        void OnVideoChanged(object sender, EventArgs e)
        {
            if (collection == null)
                return;

            videoPlayer.Open(collection[comboBox.SelectedIndex]);
            treeView.Nodes.Clear();
            foreach (Segment segment in collection[comboBox.SelectedIndex].Markers)
                treeView.Nodes.Add($"{TimeSpan.FromSeconds(segment.Start).ToString("c")} - {TimeSpan.FromSeconds(segment.End).ToString("c")}");
        }

        void OnSegmentChanged(object sender, TreeNodeMouseClickEventArgs e) =>
            videoPlayer.GoToSegment(treeView.SelectedNode.Index);

        void NextSegment(object sender, EventArgs e)
        {
            if (treeView.SelectedNode == null && treeView.Nodes.Count > 0)
                treeView.SelectedNode = treeView.Nodes[0];
            else if (treeView.SelectedNode?.Index == treeView.Nodes.Count - 1)
            {
                videoPlayer.Stop();
                return;
            }
            else
                treeView.SelectedNode = treeView.SelectedNode.NextNode;

            OnSegmentChanged(sender, null);
        }

        void PreviousSegment(object sender, EventArgs e)
        {
            if (treeView.SelectedNode.Index == 0)
                videoPlayer.GoToSegment(treeView.SelectedNode.Index);
            else
                treeView.SelectedNode = treeView.SelectedNode.PrevNode;
        }
    }
}
