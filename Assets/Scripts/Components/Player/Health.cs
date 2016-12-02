using ToughLife.Enums;
using UnityEngine;

namespace ToughLife.Components.Player
{
    public class Health
    {
        private ActiveStats ownerStats;

        public int currentHealth;
        public int maxHealth;
        public LifeState lifeState { get; set; }

        public Health(ActiveStats ownerStats)
        {
            this.ownerStats = ownerStats;
        }

        public void inflictDamage (int damage)
        {
            int tempOutcome = currentHealth - damage;
            if (tempOutcome > 0)
            {
                //DAMAGE
                currentHealth = tempOutcome;
            }
            else
            {
                //DIE
                currentHealth = 0;
                Debug.Log("death");
                ownerStats.die();
            }
        }

        public void heal(int heal)
        {
            int tempOutcome = currentHealth + heal;
            if (currentHealth <= 0)
            {
                if (tempOutcome > maxHealth)
                {
                    //HEAL
                    currentHealth = tempOutcome;
                }
                else
                {
                    //OVER-HEAL CAP
                    currentHealth = maxHealth;
                }
            }
        }
    }
}