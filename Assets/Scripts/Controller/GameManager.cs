using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using ToughLife.Enums;
using ToughLife.Interfaces;
using UnityEngine.UI;

namespace ToughLife.Controller
{
	public class GameManager : MonoBehaviour, IManager
	{
	    private Root root;

	    private float score;

	    public Text scoreText;

	    private Dictionary<GameScene, GameObject> gameSceneGUI;

	    private bool sessionRunning = false;

	    void Awake()
	    {
            gameSceneGUI = new Dictionary<GameScene, GameObject>();
	    }

	    public void Update()
	    {
	        if (sessionRunning)
	        {
	            updateScore();
	        }
	    }

	    public int getScore()
	    {
	        return Mathf.RoundToInt(score);
	    }

	    public void updateScore()
	    {
	        score += Time.deltaTime * 2f;
	        scoreText.text = Mathf.RoundToInt(score).ToString();
	    }

	    public void updateScore(float newScore)
	    {

	    }

		public string getTag ()
		{
			return "GameManager";
		}


	    public void setRoot(Root root)
	    {
	        this.root = root;
	    }



	    public void sessionScene()
	    {
	        Destroy(gameSceneGUI[GameScene.GAMEOVER]);
	        Destroy(gameSceneGUI[GameScene.MAINMENU]);
	        sessionRunning = true;
	        GameObject sessionUI = Instantiate(Resources.Load("Prefabs/SessionUI"), Vector3.one, Quaternion.identity) as GameObject;
	        sessionUI.transform.SetParent(this.gameObject.transform);
	        scoreText = sessionUI.GetComponentInChildren<Text>();
	        gameSceneGUI.Add(GameScene.SESSION, sessionUI);
	    }

	    public void gameOverScene()
	    {

	        Destroy(gameSceneGUI[GameScene.SESSION]);
	        GameObject gameOverUI = Instantiate(Resources.Load("Prefabs/GameOverUI"), Vector3.one, Quaternion.identity) as GameObject;
	        gameOverUI.transform.SetParent(this.gameObject.transform);
	        gameOverUI.GetComponent<GameOverUI>().setFinalScore(root.gameManager.getScore());
	        gameSceneGUI.Add(GameScene.GAMEOVER, gameOverUI);
	    }

	    public void mainScene()
	    {
	        Destroy(gameSceneGUI[GameScene.BOOTSTRAP]);
	        GameObject mainMenuGUI = Instantiate(Resources.Load("Prefabs/MainMenuGUI"), Vector3.one, Quaternion.identity) as GameObject;
	        mainMenuGUI.transform.SetParent(this.gameObject.transform);
	        gameSceneGUI.Add(GameScene.MAINMENU, mainMenuGUI);
	    }
	}

}
