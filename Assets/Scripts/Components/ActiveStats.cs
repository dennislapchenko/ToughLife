using ToughLife.Components.Player;
using ToughLife.Controller;
using ToughLife.Enums;
using ToughLife.Util;
using UnityEngine;

namespace ToughLife.Components
{
    public class ActiveStats
    {
        public Root root;

        public StatsOwnerType owner;
        public Health health;
        public Movement movement;
        public Abilities abilities;

        void Awake()
        {

        }

        public void die()
        {
            root.sceneController.loadScene(GameScene.GAMEOVER);
        }


        public void Life(Root root)
        {
            this.root = root;
            health = new Health(this);
            movement = new Movement(this);
            abilities = new Abilities(this);
        }
    }
}
