using UnityEngine;

namespace ToughLife.Util
{
    public class DebugUtil
    {

        public static void verifyNotNull(object obj, string descr)
        {
            if (obj == null)
            {
                Debug.Log(descr + " is null");
            }
            else
            {
                Debug.Log(descr + " is NOT null");
            }
        }
    }
}