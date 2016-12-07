using UnityEngine;
using System.Collections;
using Zenject;

namespace ToughLife {
	
	public class ProjectInstaller : MonoInstaller {
		
		
		public override void InstallBindings()
		{
			Container.BindSignal<GameStateSignals.Bootstrap>();
			Container.BindSignal<GameStateSignals.Main>();
			Container.BindSignal<GameStateSignals.Session>();
			Container.BindSignal<GameStateSignals.Gameover>();
		}
	}
	
}