using UnityEngine;

namespace ToughLife
{
    public abstract class AcidBehaviour : MonoBehaviour
    {
        //the root of all! :)
        protected Root root;

        //instead of awake (cann awake within)
        public abstract void Life(Root root);

    }
}