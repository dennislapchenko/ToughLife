using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonBinds : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void loadSessionScene()
    {
        SceneManager.LoadScene("Session");
    }
}
