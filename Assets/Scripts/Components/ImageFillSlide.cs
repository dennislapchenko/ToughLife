using ToughLife.Util;
using UnityEngine;
using UnityEngine.UI;

namespace ToughLife.Components
{
    [RequireComponent(typeof(Image))]
    public class ImageFillSlide : MonoBehaviour
    {
        public float TimeScale = 0.75f;

        Image parentComponent;

        void Start ()
        {
            parentComponent = this.GetComponent<Image>();
        }

        void Update ()
        {
            parentComponent.fillAmount = Mathf.Lerp(parentComponent.fillAmount, 1, 0.1f);
        }

        float getFill()
        {
//            Time.timeScale = TimeScale;
//
//            float value = Mathf.Sin(Time.time);
//            DBG.log("spacing sin value: " + value);
//            return value;
            return 0;
        }
    }

}