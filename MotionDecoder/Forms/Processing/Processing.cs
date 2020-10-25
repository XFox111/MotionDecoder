using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading.Tasks;
using MotionDecoder.Models;
using Newtonsoft.Json;
using System.IO;
using System.Threading;
using MotionDecoder.Properties;
using System.Collections.Generic;
using Accord.Vision.Motion;
using Accord.Video.FFMPEG;

namespace MotionDecoder
{
    public partial class Processing : Form
    {
#pragma warning disable IDE0069 // Disposable fields should be disposed
        CancellationTokenSource cts = new CancellationTokenSource();        // I disposed it on line 48
#pragma warning restore IDE0069 // Disposable fields should be disposed

        public Processing() =>
            InitializeComponent();

        /// <summary>
        /// Processes videos - analyzes them or loads pre-defined metadata
        /// </summary>
        /// <param name="paths"></param>
        /// <returns></returns>
        public async Task<Video[]> ProcessAsync(string[] paths)
        {
            List<Video> videos = new List<Video>();

            overallProgressBar.Maximum = paths.Length;

            for (int i = 0; i < paths.Length; i++)
            {
                step.Text = $"({i + 1}/{paths.Length})";

                string path = paths[i];
                Video item;
                if (File.Exists(path + ".data"))    // Checks if pre-defined metadata exists
                    try { item = JsonConvert.DeserializeObject<Video>(File.ReadAllText(path + ".data")); }  // Loads it if exists and correct
                    catch { item = await Analyze(path); }
                else
                    item = await Analyze(path);     // Analyzes video

                if (item != null)
                    videos.Add(item);

                overallProgressBar.Value++;

                if (cts.IsCancellationRequested)
                    break;
            }

            cts.Dispose();
            GC.Collect();

            return videos.Count == 0 ? null : videos.ToArray();
        }

        async Task<Video> Analyze(string path) => await Task.Run(() =>
        {
            try
            {
                BlobCountingObjectsProcessing processingAlgorithm = new BlobCountingObjectsProcessing()
                {
                    MinObjectsHeight = 35,
                    MinObjectsWidth = 35
                };
                MotionDetector detector = new MotionDetector(new TwoFramesDifferenceDetector(), processingAlgorithm);

                VideoFileReader reader = new VideoFileReader();
                List<Segment> markers = new List<Segment>();

                reader.Open(path);      // Opens video file

                progressBar.Value = 0;
                Invoke(new Action(() => progressBar.Maximum = (int)(reader.FrameCount / reader.FrameRate - 1)));

                bool isMoving = false;
                Segment temp = new Segment();

                //Algorythm
                for (int k = 1; k < (int)(reader.FrameCount / reader.FrameRate); k++)   // Loop processes every second
                {
                    for(int step = 0; step < 2; step++) // Processes two halfs of the current second
                    {
                        detector.ProcessFrame(reader.ReadVideoFrame());     // Processes frame
                        for (int i = 1; i < (int)(reader.FrameRate / 2); i++)       // Skips other frames
                            reader.ReadVideoFrame();
                    }
                    GC.Collect();   // Releases memory

                    if (processingAlgorithm.ObjectsCount > 0 && !isMoving)  // If there's any new moving object - creates new segment
                    {
                        isMoving = true;
                        temp.Start = k - 1;
                    }
                    else if (processingAlgorithm.ObjectsCount == 0 && isMoving) // If there's both opened segment and no moving objects - closes segment
                    {
                        isMoving = false;
                        temp.End = k;
                        markers.Add(temp);
                        temp = new Segment();
                    }

                    Invoke(new Action(() =>     // Updates progress bar
                    {
                        progressBar.Value++;
                        percentage.Text = $"{Math.Round((float)progressBar.Value / progressBar.Maximum * 100)}%";
                    }));

                    cts.Token.ThrowIfCancellationRequested();
                }

                // Markers post-processing
                for (int k = 0; k < markers.Count; k++)
                    if (markers[k].Duration < 3)     // Deletes segments if they last less than 3 seconds
                        markers.RemoveAt(k--);

                for (int k = 1; k < markers.Count; k++)
                    if (Segment.AbsoluteDistanceBetweenSegments(markers[k - 1], markers[k]) <= 5)
                    {
                        markers[k - 1].End = markers[k].End;     // Joins two segments if between them is less than 5 seconds
                        markers.RemoveAt(k--);
                    }

                Video video = new Video()
                {
                    Path = path,
                    Name = new FileInfo(path).Name,
                    Markers = markers
                };

                // Writing data to disk
                File.WriteAllText(path + ".data", JsonConvert.SerializeObject(video));

                return video;
            }
            catch (OperationCanceledException)
            {
                cts = new CancellationTokenSource();
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, e.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }
        });

        void Cancel(object sender, EventArgs e)
        {
            if (MessageBox.Show(Resources.cancelProcConf, Resources.questionHeader, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            cancelButton.Enabled = false;
            cts.Cancel();
        }
    }
}
