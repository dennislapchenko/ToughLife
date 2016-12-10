using System;
using UnityEngine;
using System.Collections;
using ModestTree;
using Zenject;

namespace ToughLife {
	
	public class ProjectInstaller : MonoInstaller {

        [Inject]
		private Settings _settings;
		
		public override void InstallBindings()
		{
			Container.BindSignal<GameSceneSignal>();
		}

        [Serializable]
		public class Settings
		{
			public GameObject SomeProjectObject;
		}
	}
	
}