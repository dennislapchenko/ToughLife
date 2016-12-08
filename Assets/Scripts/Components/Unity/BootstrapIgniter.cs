using System.Collections;
using ToughLife.Enums;
using Zenject;
using UnityEngine;

namespace ToughLife
{
	public class BootstrapIgniter : SleepBehaviour
    {
		GameSceneSignal _sceneSignal;

		[Inject]
		public void Construct(GameSceneSignal sceneSignal)
        {
			_sceneSignal = sceneSignal;
			StartCoroutine(Coroutine());
        }


        protected override IEnumerator Coroutine()
        {
            //display and awesome splashscreen
            yield return new WaitForSeconds(6.2f);
			Debug.Log("firing off scene signal");
			_sceneSignal.Fire(GameSceneName.MAIN_SCENE);
        }
    }

}