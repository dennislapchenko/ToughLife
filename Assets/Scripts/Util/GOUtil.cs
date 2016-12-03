using UnityEngine;

namespace ToughLife.Util
{
    public class GOUtil : MonoBehaviour
    {

        public static GameObject inst(string path, string name = null)
        {
            GameObject obj = Instantiate(Resources.Load(path)) as GameObject;
            if (name != null) obj.name = name;
            return obj;
        }
    }
}