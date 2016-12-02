using UnityEngine;
using ToughLife.Controller;
using ToughLife.Managers;
using ToughLife.Util;

namespace ToughLife
{
	public class Root : MonoBehaviour {


		public PlayerManager playerManager;
		public GameManager gameManager;
		public ObstacleManager obstacleManager;
	    public SceneController sceneController;
		private EnvironmentManager environmentManager;
		private AudioManager audioManager;
		private DataPersistance dataPersistance;


		void Awake()
		{
		    GameObject.DontDestroyOnLoad(this);

			GameObject pm = new GameObject("PlayerManager");
		    playerManager = pm.AddComponent<PlayerManager>();
		    playerManager.setRoot(this);
		    pm.transform.SetParent(this.gameObject.transform);

		    GameObject gm = new GameObject("GameManager");
		    gameManager = gm.AddComponent<GameManager>();
		    gameManager.setRoot(this);
		    gm.transform.SetParent(this.gameObject.transform);

		    GameObject om = new GameObject("ObstacleManager");
		    obstacleManager = om.AddComponent<ObstacleManager>();
		    obstacleManager.setRoot(this);
		    om.transform.SetParent(this.gameObject.transform);

		    GameObject sc = new GameObject("SceneController");
		    sceneController = sc.AddComponent<SceneController>();
		    sceneController.setRoot(this);
		    sc.transform.SetParent(this.gameObject.transform);
		}
		void Start()
		{
		}

		void Update()
		{

		}

	    public void loadScene(string gameoverScene)
	    {
	        sceneController.loadScene(gameoverScene);
	    }
	}
}
