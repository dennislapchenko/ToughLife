using UnityEngine;
using System.Collections;
using Zenject;

namespace ToughLife {
	
	public class ProjectInstaller : MonoInstaller {
		
		
		public override void InstallBindings()
		{
			Container.BindSignal<GameSceneSignal>();

			Container.Bind<SceneLoader>().To<SceneLoader>().FromGameObject().AsSingle().NonLazy();
		}
	}
	
}