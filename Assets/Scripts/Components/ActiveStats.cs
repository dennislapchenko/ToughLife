using ToughLife.Components.Player;
using ToughLife.Controller;
using ToughLife.Enums;
using ToughLife.Util;
using UnityEngine;

namespace ToughLife.Components
{
    public class ActiveStats : MonoBehaviour
    {
        public Root root;

        public StatsOwnerType owner;
        public Health health;
        public Movement movement;
        public Abilities abilities;

        void Awake()
        {
            health = new Health(this);
            movement = new Movement(this);
            abilities = new Abilities(this);
        }

        public void die()
        {
            root.sceneController.loadScene(GameScene.GAMEOVER);
        }

        public void setRoot(Root root)
        {
            this.root = root;
        }








    }
}
