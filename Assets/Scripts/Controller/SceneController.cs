using ToughLife;
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
            if (SceneManager.GetActiveScene().name.Equals("GameOver"))
            {

            }

        }

        public void loadScene(string name)
        {
            SceneManager.LoadScene(name);
            switch(SceneManager.GetActiveScene().name)
            {
                case(BOOTSTRAP_SCENE):
                    //is loaded initially
                    break;
                case(MAINMENU_SCENE):
                    root.gameManager.mainScene();
                    break;
                case(SESSION_SCENE):
                    root.gameManager.sessionScene();
                    break;
                case(GAMEOVER_SCENE):
                    root.gameManager.gameOverScene();
                    break;
            }
        }
    }
}