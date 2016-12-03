using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonColorGlow : MonoBehaviour
{
	public float TimeScale = 0.75f;
	public bool OscillateRed = true;
	public bool OscillateGreen = false;
	public bool OscillateBlue = false;
	[Range(0,255)]
	public byte Red = 230;
	[Range(0,255)]
	public byte Green = 10;
	[Range(0,255)]
	public byte Blue = 10;
	[Range(0,255)]
	public byte Alpha = 255;

	Button parentComponent;

	void Start () 
	{
		parentComponent = this.GetComponent<Button>();
	}

	void Update ()
	{

	    parentComponent.colors = getColorBlockColor();
	}

	Color32 getColor()
	{
		Time.timeScale = TimeScale;
		byte R = OscillateRed ? (byte) (Mathf.Abs(Mathf.Sin(Time.time)) * Red) : Red;
		byte G = OscillateGreen ? (byte) (Mathf.Abs(Mathf.Sin(Time.time)) * Green) : Green;
		byte B = OscillateBlue ? (byte) (Mathf.Abs(Mathf.Sin(Time.time)) * Blue) : Blue;
		return new Color32(R, G, B, Alpha); //R, G, B, Alpha
	}

    ColorBlock getColorBlockColor()
    {
        ColorBlock cblock = parentComponent.colors;
        cblock.normalColor = getColor();
        return cblock;
    }
}
