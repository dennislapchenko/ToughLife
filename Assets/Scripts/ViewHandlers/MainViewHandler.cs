using System;
using Zenject;
using UnityEngine.UI;

namespace ToughLife
{
	public class MainViewHandler : IInitializable, IDisposable
	{
		[Inject(Id="PLAY")]
		Button _playButton;
		[Inject]
		GameSceneSignal _gameSignal;

		void IInitializable.Initialize ()
		{
			_playButton.onClick.AddListener(() => _gameSignal.Fire(GameSceneName.SESSION_SCENE));
		}

		void IDisposable.Dispose ()
		{
			_playButton.onClick.RemoveListener(() =>_gameSignal.Fire(GameSceneName.SESSION_SCENE));
		}
	}
}

