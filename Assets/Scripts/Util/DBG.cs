using UnityEngine;

namespace ToughLife.Util
{
    public class DBG : MonoBehaviour
    {

        public static void log(object logText)
        {
            Debug.Log(logText.ToString());
        }

        public static void logf(string logtext, object[] args)
        {
            Debug.LogFormat(logtext, args);
        }
    }
}