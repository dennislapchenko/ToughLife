using System.Collections;
using ToughLife.Enums;
using Zenject;
using UnityEngine;

namespace ToughLife
{
	public class BootstrapIgniter : MonoBehaviour
    {
		GameSceneSignal _sceneSignal;

		[Inject]
		public void Construct(GameSceneSignal sceneSignal)
        {
			_sceneSignal = sceneSignal;
            StartCoroutine(sleepAndLoad());
        }


        private IEnumerator sleepAndLoad()
        {
            //display and awesome splashscreen
            yield return new WaitForSeconds(2.2f);
			Debug.Log("firing off main scene signal");
			_sceneSignal.Fire("pipisjka");
        }
    }

}