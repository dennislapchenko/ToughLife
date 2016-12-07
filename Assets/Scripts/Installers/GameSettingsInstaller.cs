using UnityEngine;
using Zenject;

namespace ToughLife
{
	[CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/GameSettingsInstaller")]
	public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
	{
		public BootstrapInstaller.Settings bootstrapSettings;

		public override void InstallBindings()
		{
			Container.BindInstance(bootstrapSettings);
		}
	}
}