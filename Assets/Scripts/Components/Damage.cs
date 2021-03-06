﻿using UnityEngine;
using System.Collections;
using ToughLife.Components;
using ToughLife.Enums;

public class Damage : MonoBehaviour {

	public int damage = 25;


	void OnCollisionEnter(Collision collision)
	{
		Debug.Log("collision damage");
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log("DAMAGE!");
		
		ActiveStats attr = other.gameObject.GetComponent<ActiveStats>();
	    Debug.Log(string.Format("attribute {0}", other.gameObject.name));
	    if (attr != null)
	    {
	        if (!attr.abilities.getShieldActive())
	        {
	            attr.health.inflictDamage(damage);
	        }
	    }
	}

}
