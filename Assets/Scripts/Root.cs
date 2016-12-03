using System.Collections.Generic;
using ToughLife.Components.Unity;
using UnityEngine;
using ToughLife.Controller;
using ToughLife.Enums;
using ToughLife.Interfaces;
using ToughLife.Managers;
using ToughLife.Util;
using UnityEngine.SceneManagement;

namespace ToughLife
{
	public class Root : MonoBehaviour {


		public PlayerManager playerManager;
		public GameManager gameManager;
		public ObstacleManager obstacleManager;
	    public SceneController sceneController;
		public EnvironmentController environmentController;
		private AudioManager audioManager;
		private DataPersistance dataPersistance;

	    private List<GameObject> instantiatedManagers;


		void Awake()
		{
		    DontDestroyOnLoad(this);

		    instantiatedManagers = new List<GameObject>();

		    loadSceneController();
		    loadGameManager();
		    loadEnvironmentManager();
		}

	    public void loadManagersForScene(GameScene scene)
	    {
	        cleanObjects();
	        switch (scene)
	        {
	            case(GameScene.MAINMENU):
	                break;
	            case(GameScene.SESSION):
	                loadPlayerManager();
	                loadObstacleManager();
	                break;
	                case(GameScene.GAMEOVER):
	                break;
	                default:
	                break;
	        }
	    }

	    private void loadSceneController()
	    {
	        GameObject sc = new GameObject("SceneController");
	        sceneController = sc.AddComponent<SceneController>();
	        sceneController.setRoot(this);
	        sc.transform.SetParent(this.gameObject.transform);
	    }

	    private void loadEnvironmentManager()
	    {
	        GameObject ec = new GameObject("Environment Manager");
	        environmentController = ec.AddComponent<EnvironmentController>();
	        environmentController.Life(this);
	        ec.transform.SetParent(this.gameObject.transform);
	    }

	    private void loadPlayerManager()
	    {
	        GameObject pm = new GameObject("PlayerManager");
	        playerManager = pm.AddComponent<PlayerManager>();
	        playerManager.setRoot(this);
	        pm.transform.SetParent(this.gameObject.transform);
	        instantiatedManagers.Add(pm);

	    }

	    private void loadGameManager()
	    {
	        GameObject gm = new GameObject("GameManager");
	        gameManager = gm.AddComponent<GameManager>();
	        gameManager.setRoot(this);
	        gm.transform.SetParent(this.gameObject.transform);

	    }
	    private void loadObstacleManager()
	    {
	        GameObject om = new GameObject("ObstacleManager");
	        obstacleManager = om.AddComponent<ObstacleManager>();
	        obstacleManager.setRoot(this);
	        om.transform.SetParent(this.gameObject.transform);
	        instantiatedManagers.Add(om);

	    }



	    private void cleanObjects()
	    {
	        foreach (GameObject go in instantiatedManagers)
	        {
	            Destroy(go);
	        }
	        instantiatedManagers = new List<GameObject>();
	    }


		void Start()
		{
		    GameObject booter = Instantiate(Resources.Load("Prefabs/Unity/sleepAwake")) as GameObject;
		    booter.transform.SetParent(this.transform);
		    booter.GetComponent<BootstrapIgniter>().Life(this);
		}

	    void Update()
	    {
	    }
	}
}
