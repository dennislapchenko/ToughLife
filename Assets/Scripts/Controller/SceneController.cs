using ToughLife;
using ToughLife.Enums;
using ToughLife.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ToughLife.Controller
{
    public class SceneController : MonoBehaviour, IManager
    {
        private Root root;

        public const string BOOTSTRAP_SCENE = "Bootstrap";
        public const string MAINMENU_SCENE = "Main";
        public const string SESSION_SCENE = "Session";
        public const string GAMEOVER_SCENE = "GameOver";

        public string getTag()
        {
            return "";
        }

        public void setRoot(Root root)
        {
            this.root = root;
        }

        void Awake()
        {

        }

        public void loadScene(GameScene scene)
        {
            string sceneToLoad = "";
            switch(scene)
            {
                case(GameScene.BOOTSTRAP):
                    //is loaded initially
                    sceneToLoad = BOOTSTRAP_SCENE;
                    break;
                case(GameScene.MAINMENU):
                    sceneToLoad = MAINMENU_SCENE;
                    root.gameManager.mainScene();
                    break;
                case(GameScene.SESSION):
                    sceneToLoad = SESSION_SCENE;
                    root.gameManager.sessionScene();
                    break;
                case(GameScene.GAMEOVER):
                    sceneToLoad = GAMEOVER_SCENE;
                    root.gameManager.gameOverScene();
                    break;
            }
            SceneManager.LoadScene(sceneToLoad);
            root.loadManagersForScene(scene);
        }
    }
}