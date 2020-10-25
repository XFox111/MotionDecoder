using System.Collections.Generic;

namespace MotionDecoder.Models
{
    /// <summary>
    /// Represents video metadata
    /// </summary>
    public class Video
    {
        /// <summary>
        /// Absolute path to the file
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// Video file name including extension
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Set of <see cref="Segment"/> found in the video
        /// </summary>
        public List<Segment> Markers { get; set; }
    }
}
