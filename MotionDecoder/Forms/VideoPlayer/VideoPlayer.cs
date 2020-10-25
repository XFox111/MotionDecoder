using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MotionDecoder.Forms;
using MotionDecoder.Models;
using MotionDecoder.Properties;

namespace MotionDecoder
{
    public enum PlayState { Playing, Paused, Stopped, Empty, Unencoutered }

    public partial class VideoPlayer : UserControl
    {
        public List<Segment> playlist = new List<Segment>();
        Microsoft.DirectX.AudioVideoPlayback.Video video;

        int checkpoint = -100;

        public event EventHandler NextSegmentRequested;
        public event EventHandler PreviousSegmentRequested;

        public VideoPlayer()
        {
            InitializeComponent();

            volumeBar.Value = Settings.Default.volume;
        }

        public void Play()
        {
            if (video == null)
                return;

            if (checkpoint == -100 && cut.Checked)
            {
                NextSegmentRequested?.Invoke(this, null);
                return;
            }

            video.Play();
            timer.Start();
            TimerTicked(this, null);

            playBtn.Text = "\x23F8";
        }

        public void Pause()
        {
            if (video == null)
                return;

            video.Pause();
            timer.Stop();

            playBtn.Text = "\x23F5";
        }

        public void Stop()
        {
            if (video == null)
                return;

            video.Stop();
            timer.Stop();
            TimerTicked(this, null);

            playBtn.Text = "\x23F5";
        }

        public void IncrementVolume() =>
            volumeBar.Value++;
        public void DecrementVolume() =>
            volumeBar.Value--;

        void NextClicked(object sender, EventArgs e) =>
            NextSegmentRequested?.Invoke(this, null);

        void PreviousClicked(object sender, EventArgs e) =>
            PreviousSegmentRequested?.Invoke(this, null);

        void StopClicked(object sender, EventArgs e) =>
            Stop();

        void PlayClicked(object sender, EventArgs e)
        {
            if (video == null)
                return;

            if(video.State == Microsoft.DirectX.AudioVideoPlayback.StateFlags.Running)
                Pause();
            else
                Play();
        }

        public void Clear()
        {
            Stop();
            playlist.Clear();
            video?.Dispose();
            video = null;
            trackBar.Value = 0;
            trackBar.Enabled = false;
        }

        public void Open(Video source)
        {
            Clear();
            Size size = outputFrame.Size;
            video = new Microsoft.DirectX.AudioVideoPlayback.Video(source.Path) { Owner = outputFrame };
            outputFrame.Size = size;
            playlist.AddRange(source.Markers);

            trackBar.Maximum = (int)video.Duration;
            trackBar.Enabled = !cut.Checked;

            video.Audio.Volume = volumeBar.Value;
        }

        public void GoToSegment(int index)
        {
            if (video == null)
                return;

            video.CurrentPosition = Mathf.Clamp(playlist[index].Start - 5, 0, video.Duration);
            checkpoint = (int)video.CurrentPosition + playlist[index].Duration + 15;

            Play();
        }

        public void VolumeChanged(object sender, EventArgs e)
        {
            if(video != null) 
                video.Audio.Volume = volumeBar.Value;

            Settings.Default.volume = volumeBar.Value;
            Settings.Default.Save();
        }

        void CutChanged(object sender, EventArgs e)
        {
            if (video == null)
                return;

            Pause();
            trackBar.Enabled = !cut.Checked;
        }

        void TimerTicked(object sender, EventArgs e)
        {
            trackBar.Value = (int)video.CurrentPosition;
            timeCodeLabel.Text = TimeSpan.FromSeconds(video.CurrentPosition).ToString(@"hh\:mm\:ss") + " / " + TimeSpan.FromSeconds(video.Duration).ToString(@"hh\:mm\:ss");

            if (cut.Checked && (int)video.CurrentPosition == checkpoint)
                NextSegmentRequested?.Invoke(this, null);
        }

        void SeekPositionChanged(object sender, EventArgs e)
        {
            if (video == null)
                return;

            video.CurrentPosition = trackBar.Value;
            Play();
        }
    }
}
