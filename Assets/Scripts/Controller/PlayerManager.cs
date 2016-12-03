using System;
using ToughLife.Components;
using ToughLife.Enums;
using ToughLife.Interfaces;
using ToughLife.Util;
using UnityEngine;

namespace ToughLife.Controller
{
	public class PlayerManager : MonoBehaviour, IManager
	{
	    private Root root;

		public GameObject player;
		public ActiveStats activeStats;

		public string getTag () { return "PlayerManager"; }

	    public void setRoot(Root root)
	    {
	        this.root = root;
	        initiate();
	    }

		void Awake()
		{

		}

	    private void initiate()
	    {
	        playerBuild(25);
	    }


		void LateUpdate()
		{
//			switch(currentState)
//			{
//				case(PlayerStates.Active):
//					player.SetActive(true);
//					break;
//				case(PlayerStates.Dead):
//					break;
//				case(PlayerStates.Inactive):
//					player.SetActive(false);
//					break;
//			}
			
		}

		private void playerBuild(int healthPoints)
		{
			player = Instantiate(Resources.Load("Prefabs/Player"), Vector3.zero, Quaternion.identity) as GameObject;
			activeStats = player.GetComponent<ActiveStats>();
			activeStats.health.maxHealth = healthPoints;
			activeStats.health.currentHealth = healthPoints;
			activeStats.movement.speed = 3.0f;
		    activeStats.owner = StatsOwnerType.PLAYER;
		    DebugUtil.verifyNotNull(root, "root in playerBuild()");
		    activeStats.setRoot(root);

		    player.transform.SetParent(this.transform);
		}

	    public Root getRoot()
	    {
	        return root;
	    }
	}
}

