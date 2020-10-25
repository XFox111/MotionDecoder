using System;

namespace MotionDecoder.Models
{
    /// <summary>
    /// Video segment metadata
    /// </summary>
    public class Segment
    {
        public int Start { get; set; }
        public int End { get; set; }
        public int Duration => End - Start;

        /// <summary>
        /// Creates new class instance
        /// </summary>
        public Segment() : this(0, 0) { }
        /// <summary>
        /// Creates new class instance
        /// </summary>
        /// <exception cref="System.NotSupportedException">Thrown when <paramref name="firstSecond"/> is greater than <paramref name="lastSecond"/></exception>
        /// <param name="firstSecond">Second in the video where the segment begins</param>
        /// <param name="lastSecond">Second in the video where the segment ends (must be greater or equal than</param>
        public Segment(int firstSecond, int lastSecond)
        {
            if (firstSecond > lastSecond)
                throw new NotSupportedException("Segment must begin earlier than end");
            Start = firstSecond;
            End = lastSecond;
        }

        /// <summary>
        /// Calculates time between end of <paramref name="seg1"/> segment and begining of <paramref name="seg2"/> segment
        /// </summary>
        /// <param name="seg1">First segment which is intended to be first in the time line</param>
        /// <param name="seg2">Second segment</param>
        /// <returns>Time spent between two segments</returns>
        public static int AbsoluteDistanceBetweenSegments(Segment seg1, Segment seg2) =>
            Math.Abs(seg2.Start - seg1.End);
    }
}
