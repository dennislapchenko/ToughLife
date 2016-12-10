using System;
using UnityEngine;
using Zenject;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace ToughLife
{
	public class SceneLoader : IInitializable, IDisposable
	{
		GameSceneSignal _sceneSignal;
		ZenjectSceneLoader _sceneLoader;

		public SceneLoader(ZenjectSceneLoader sceneLoader, GameSceneSignal sceneSignal)
		{
			_sceneLoader = sceneLoader;
			_sceneSignal = sceneSignal;
		}

		public void Initialize ()
		{
			_sceneSignal += GameScene;
		}

		public void Dispose ()
		{
			_sceneSignal -= GameScene;
		}


		void GameScene(string sceneName)
		{
			Debug.Log("SCENE LOADING: "+sceneName);
			_sceneLoader.LoadScene(sceneName);
		}
	}
}

