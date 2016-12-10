using System;
using UnityEngine;
using Zenject;
using UnityEngine.UI;

namespace ToughLife
{
	public class MainInstaller : MonoInstaller
	{
        [Inject]
        Settings _settings = null;

		[Inject(Id="PLAY")]
		Button _playButton;

		public override void InstallBindings()
		{
			//bind play and title
			Container.BindAllInterfaces<MainViewHandler>().To<MainViewHandler>().AsSingle().NonLazy();
			Container.Bind<IInitializable>().To<SceneLoader>().AsSingle();

			//bind highscores

		}

		[Serializable]
	    public class Settings
	    {
	        public GameObject MainViewGUI;
	    }
	}
}