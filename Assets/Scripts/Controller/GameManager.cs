using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using ToughLife.Enums;
using ToughLife.Interfaces;
using ToughLife.Util;
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
	        GOUtil.inst("Prefabs/EventSystem").transform.SetParent(this.transform);
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

	    public Root getRoot()
	    {
	        return this.root;
	    }
	    private void destroyGUIifExists(GameScene scene)
	    {
	        if (gameSceneGUI.ContainsKey(scene))
	        {
	            Destroy(gameSceneGUI[scene]);
	            gameSceneGUI.Remove(scene);
	        }
	    }

	    public void sessionScene()
	    {
	        destroyGUIifExists(GameScene.GAMEOVER);
	        destroyGUIifExists(GameScene.MAINMENU);
	        sessionRunning = true;
	        GameObject sessionUI = Instantiate(Resources.Load("Prefabs/SessionUI"), Vector3.one, Quaternion.identity) as GameObject;
	        sessionUI.transform.SetParent(this.gameObject.transform);
	        scoreText = sessionUI.GetComponentInChildren<Text>();
	        gameSceneGUI.Add(GameScene.SESSION, sessionUI);
	    }

	    public void gameOverScene()
	    {

	        sessionRunning = false;
	        destroyGUIifExists(GameScene.SESSION);
	        GameObject gameOverUI = Instantiate(Resources.Load("Prefabs/GameOverUI"), Vector3.one, Quaternion.identity) as GameObject;
	        gameOverUI.transform.SetParent(this.gameObject.transform);
	        gameOverUI.GetComponent<GameOverUI>().setFinalScore(root.gameManager.getScore());
	        gameSceneGUI.Add(GameScene.GAMEOVER, gameOverUI);
	    }

	    public void mainScene()
	    {
	        destroyGUIifExists(GameScene.BOOTSTRAP);
	        GameObject mainMenuGUI = Instantiate(Resources.Load("Prefabs/MainGUI"), Vector3.one, Quaternion.identity) as GameObject;
	        mainMenuGUI.transform.SetParent(this.gameObject.transform);
	        gameSceneGUI.Add(GameScene.MAINMENU, mainMenuGUI);
	    }
	}

}
