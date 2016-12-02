using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ToughLife.Components;
using ToughLife.Enums;
using ToughLife.Interfaces;

namespace ToughLife.Controller
{
	public class ObstacleManager : MonoBehaviour, IManager
	{
	    private Root root;

	    public int obstacleAmount = 3;

	    private GameObject[] obstacles;
	    private List<AImove> ai;
	    public bool shouldRecount = false;
		public string getTag () { return "ObstacleManager"; }

	    public void setRoot(Root root)
	    {
	        this.root = root;
	        initiate();
	    }

	    private float ceiling = 7.0f;

	    void initiate()
	    {
	        ai = new List<AImove>();
	        createObstacles();
	    }


		void Awake()
		{

		}

		void createObstacles()
		{
			obstacles = new GameObject[obstacleAmount];
			for (int i = 0; i < obstacles.Length; i++)
			{
			    GameObject obstacle = Instantiate(Resources.Load("Prefabs/Obstacle"), new Vector3(Random.Range(-2.5f,2.5f),ceiling,0), Quaternion.identity) as GameObject;
			    ActiveStats attr = obstacle.GetComponent<ActiveStats>();
			    attr.movement.speed = (attr.movement.speed = Random.Range(2, 7));
			    attr.owner = StatsOwnerType.OBSTACLE;
			    attr.setRoot(root);

			    ai.Add(obstacle.GetComponent<AImove>());
			    obstacle.transform.SetParent(this.transform);
			    obstacles[i] = obstacle;
			}
		}

		void Update()
		{
		    foreach (AImove mover in ai)
		    {
		        //mover.doCycle(Vector3.back);
		        mover.doCycle();
		    }
			if (shouldRecount)
				redrawObstacles();
		}

		void redrawObstacles()
		{
			foreach (GameObject obst in obstacles)
			{
				Destroy(obst);
			}
			for (int i = 0; i < obstacleAmount; i++)
			{
				obstacles[i] = Instantiate(Resources.Load("Prefabs/Obstacle"), new Vector3(Random.Range(-2.5f, 2.5f),ceiling,0), Quaternion.identity) as GameObject;
				ActiveStats attr = obstacles[i].GetComponent<ActiveStats>();
				attr.movement.speed = Random.Range(3,10);
			}
			shouldRecount = false;
		}
	}

}
