using ToughLife.Util;
using UnityEngine;
using UnityEngine.UI;

namespace ToughLife.Components
{
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
    }
}