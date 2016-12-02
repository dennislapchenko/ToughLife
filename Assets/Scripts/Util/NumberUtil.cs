using UnityEngine;

namespace ToughLife.Util
{
    public class NumberUtil
    {

        public static bool isApproximately(float a, float b)
        {
            return isApproximately(a, b, 0.02f);
        }

        public static bool isApproximately(float a, float b, float tolerance)
        {
            return Mathf.Abs(a - b) < tolerance;
        }
    }
}