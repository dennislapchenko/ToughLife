using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToughLife.Components.Player
{
    public class Abilities
    {
        private ActiveStats ownerStats;

        private bool shieldActive = false;

        public Abilities(ActiveStats owner)
        {
            ownerStats = owner;
        }

        public bool getShieldActive()
        {
            return shieldActive;
        }

//        private IEnumerator activate(float ms)
//        {
//            shieldActive = true;
//            yield return new WaitForSeconds(ms/1000);
//            shieldActive = false;
//        }
//
//        public void activateShield(float ms)
//        {
//            StartCoroutine(activate(ms));
//        }


    }
}
