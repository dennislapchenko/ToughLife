using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ToughLife.Components;
using ToughLife.Enums;
using ToughLife.Interfaces;
using ToughLife.Util;

namespace ToughLife.Controller
{
	public class ObstacleManager : MonoBehaviour, IManager
	{
	    private Root root;

	    public int obstacleAmount = 3;

	    private List<GameObject> obstacles;
	    private List<AImove> ai;
	    public bool shouldRecount = false;
		public string getTag () { return "ObstacleManager"; }

	    private Vector3 screen;

	    public void setRoot(Root root)
	    {
	        this.root = root;
	        initiate();
	    }

	    private float ceiling = 7.0f;

	    void initiate()
	    {
	        ai = new List<AImove>();
	        obstacleAmount = Random.RandomRange(3, 7);
	        createObstacles();
	    }

		public void createObstacles()
		{
//		    screen = root.environmentController.getScreenToWorld();
//		    obstacles = new List<GameObject>();
//		    for (int i = 0; i < obstacleAmount; i++)
//		    {
//		        StartCoroutine(newObstacle());
//		    }
		}

	    public IEnumerator newObstacle()
	    {
	        GameObject obstacle = Instantiate(Resources.Load("Prefabs/Obstacle"), new Vector3(Random.Range(-screen.x, screen.x),screen.y,0), Quaternion.identity) as GameObject;
	        ActiveStats attr = obstacle.GetComponent<ActiveStats>();
	        attr.Life(root);
	        attr.movement.speed = Random.Range(4, 12);
	        attr.owner = StatsOwnerType.OBSTACLE;

	        AImove aiMove = obstacle.GetComponent<AImove>();
	        aiMove.setBounds(screen.x, -screen.x, screen.y, 0);
	        Transform obstacleScale = obstacle.transform;
	        obstacleScale.localScale =
	            obstacle.transform.localScale = new Vector3(Random.value+0.3f, 1, 1);
	        obstacle.transform.SetParent(transform);
	        obstacles.Add(obstacle);

	        yield return new WaitForSeconds(1);
	        ai.Add(aiMove);

	        obstacle.SetActive(true);
	    }

	    public void spawnObstacle()
	    {
	        DBG.log("Spawning new obstacle");
	        StartCoroutine(newObstacle());
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
