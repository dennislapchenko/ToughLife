using UnityEngine;
using System.Collections;
using ToughLife.Components;
using ToughLife.Util;

public class MoveInput : MonoBehaviour {

	private ActiveStats activeStats;

    private float xMin;
    private float xMax;
    private float currentValue = 0;

	void Start () {
	    if (gameObject.GetComponent<ActiveStats>() != null)
	    {
	        activeStats = gameObject.GetComponent<ActiveStats>();
	    }
	    Vector3 screen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
	    xMin = (-screen.x) - (transform.localScale.x / 2.5f);
	    xMax = screen.x + (transform.localScale.x / 2.5f);
	}
	
	void Update ()
	{
	    float direction = Input.GetAxis("Horizontal");
	    if (activeStats != null && !activeStats.movement.rooted)
	    {
	        currentValue += Time.unscaledDeltaTime * direction * activeStats.movement.speed;
	        // or however you are incrementing the position
	        if (currentValue >= xMax)
	        {
	            currentValue = xMax;
	        }
	        else if (currentValue <= xMin)
	        {
	            currentValue = xMin;
	        }
	        transform.localPosition = new Vector3(currentValue, transform.localPosition.y, transform.localPosition.z);
	    }
	}
}
