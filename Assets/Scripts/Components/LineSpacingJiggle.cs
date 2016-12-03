using ToughLife.Util;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LineSpacingJiggle : MonoBehaviour
{
    public float TimeScale = 0.75f;
//    public bool OscillateRed = true;
//    public bool OscillateGreen = false;
//    public bool OscillateBlue = false;
//    [Range(0,255)]
//    public byte Red = 230;
//    [Range(0,255)]
//    public byte Green = 10;
//    [Range(0,255)]
//    public byte Blue = 10;
//    [Range(0,255)]
//    public byte Alpha = 255;

    Text parentComponent;

    void Start ()
    {
        parentComponent = this.GetComponent<Text>();
    }

    void Update ()
    {
        parentComponent.lineSpacing = getSpacing();
    }

    float getSpacing()
    {
        Time.timeScale = TimeScale;

        float value = Mathf.Sin(Time.time);
        //DBG.log("spacing sin value: " + value);
        return value;
    }
}
