using System;
using UnityEngine;
using Zenject;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace ToughLife
{
	public class SceneLoader : MonoBehaviour
	{
		GameSceneSignal _sceneSignal;

		[Inject]
		public void Construct (GameSceneSignal sceneSignal)
		{
			_sceneSignal = sceneSignal;
			_sceneSignal += GameScene;
		}

		void GameScene(string sceneName)
		{
			Debug.Log("SCENE LOADINK = "+sceneName);
		}
	}
}

