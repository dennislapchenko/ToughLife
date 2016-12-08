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
		ZenjectSceneLoader _sceneLoader;

		[Inject]
		public void Construct (ZenjectSceneLoader sceneLoader, GameSceneSignal sceneSignal)
		{
			_sceneLoader = sceneLoader;
			_sceneSignal = sceneSignal;
			_sceneSignal += GameScene;
		}

		void GameScene(string sceneName)
		{
			Debug.Log("SCENE LOADINK = "+sceneName);
			_sceneLoader.LoadScene(sceneName);
		}
	}
}

