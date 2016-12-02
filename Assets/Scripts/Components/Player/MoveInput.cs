using UnityEngine;
using System.Collections;
using ToughLife.Components;

public class MoveInput : MonoBehaviour {

	private ActiveStats activeStats;

	void Start () {
		if (this.gameObject.GetComponent<ActiveStats>() != null)
			activeStats = this.gameObject.GetComponent<ActiveStats>();
	}
	
	void Update () {
		if (activeStats != null && !activeStats.movement.rooted)
			this.gameObject.transform.Translate(activeStats.movement.speed * Time.deltaTime  * 1.3f * Input.GetAxis("Horizontal"), 0, 0);
	}
}
