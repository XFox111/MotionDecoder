namespace MotionDecoder
{
    public static class Mathf
    {
        /// <summary>
        /// Clamps value between to numbers
        /// Returns <paramref name="min"/> if <paramref name="value"/> is less than <paramref name="min"/>, <paramref name="max"/> if the value is greater than <paramref name="max"/>. Otherwise returns <paramref name="value"/>
        /// </summary>
        /// <returns>Returns <paramref name="min"/> if <paramref name="value"/> is less than <paramref name="min"/>, <paramref name="max"/> if the value is greater than <paramref name="max"/>. Otherwise returns <paramref name="value"/></returns>
        public static double Clamp(double value, double min, double max)
        {
            if (value < min)
                return min;
            else if (value > max)
                return max;
            else return value;
        }
    }
}