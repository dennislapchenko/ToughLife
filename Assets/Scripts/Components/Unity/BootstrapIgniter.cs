using System.Collections;
using ToughLife.Enums;
using ToughLife.Util;
using UnityEngine;

namespace ToughLife.Components.Unity
{
    public class BootstrapIgniter : AcidBehaviour
    {

        private const GameScene sceneToLoad = GameScene.MAINMENU;

        private GameObject splashObject;

        private IEnumerator sleepAndLoad()
        {
            //display and awesome splashscreen
            yield return new WaitForSeconds(2.2f);
            root.sceneController.loadScene(GameScene.MAINMENU);
            Destroy(this.gameObject);

        }

        public override void Life(Root root)
        {
            this.root = root;
            Debug.Log("Starting coroutine bootstrap igniter");
            splashObject = GOUtil.inst("Prefabs/BootstrapGUI");
            splashObject.transform.SetParent(this.transform);
            StartCoroutine(sleepAndLoad());
        }
    }

}