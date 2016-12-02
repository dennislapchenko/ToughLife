using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{

    private Text finalScore;
    private Text gameOverMessage;

	void Awake ()
	{
	    IEnumerable<Text> texts = GetComponentsInChildren<Text>();
	    finalScore = texts.FirstOrDefault(x => x.name.Contains("finalScore"));
	    gameOverMessage = texts.FirstOrDefault(x => x.name.Contains("GGWP"));
	}
	
	void Update () {
	
	}

    public void setFinalScore(int finalScore)
    {
        this.finalScore.text = finalScore.ToString();
    }
}
