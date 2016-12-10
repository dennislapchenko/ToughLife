using UnityEngine;
using Zenject;

namespace ToughLife
{
	[CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/GameSettingsInstaller")]
	public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
	{
		public ProjectInstaller.Settings projectInstallerSettings;
		public BootstrapInstaller.Settings bootstrapInstallerSettings;
		public MainInstaller.Settings mainSceneInstaller;

		public override void InstallBindings()
		{
			Container.BindInstance(bootstrapInstallerSettings);
		    Container.BindInstance(projectInstallerSettings);
			Container.BindInstance(mainSceneInstaller);
		}
	}
}