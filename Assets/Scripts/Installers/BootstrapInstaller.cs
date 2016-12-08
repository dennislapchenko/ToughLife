using System;
using Zenject;
using UnityEngine;

namespace ToughLife
{
	public class BootstrapInstaller : MonoInstaller
	{
		[Inject]
		Settings _settings = null;

		public override void InstallBindings()
		{
			Container.Bind<BootstrapIgniter>().FromPrefab(_settings.SplashScreenPrefab).AsSingle();
			Container.Bind<BootstrapHandler>().To<BootstrapHandler>().AsSingle().NonLazy();

			//Container.Bind<ZenjectSceneLoader>().To<ZenjectSceneLoader>().AsSingle();
			Container.Bind<SceneLoader>().To<SceneLoader>().FromGameObject().AsSingle().NonLazy();
		}

		[Serializable]	
		public class Settings
		{
			public GameObject SplashScreenPrefab;
		}
	}

}