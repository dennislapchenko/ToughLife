using System.Xml.Schema;
using ToughLife.Util;
using UnityEngine;

namespace ToughLife.Components
{
    public class AImove : MonoBehaviour
    {

        private ActiveStats activeStats;
        private float verticalMax = 7.0f;
        private float verticalMin = 0.0f;
        private float leftMax = -2.25f;
        private float rightMax = 2.25f;
        private float currentValue = 7.0f;
        private int direction = -1;

        private bool changingColumns = false;

        public void setBounds(float xMax, float xMin, float yMax, float yMin)
        {
            verticalMax = yMax;
            verticalMin = yMin;
            leftMax = xMin;
            rightMax = xMax;
        }

        void Awake()
        {
            if (gameObject.GetComponent<ActiveStats>() != null)
                activeStats = gameObject.GetComponent<ActiveStats>();
        }

        public void doCycle(Vector3 direction)
        {
            if (!activeStats.movement.rooted)
            {
                float pingPong = Mathf.PingPong(Time.time * activeStats.movement.speed, 7);
                gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x,
                    pingPong,
                    gameObject.transform.localPosition.z);
            }
        }

        public void doCycle()
        {
            if (!activeStats.movement.rooted)
            {
                if (changingColumns)
                {
                    doHorizontalCycle();
                    return;
                }
                currentValue += Time.unscaledDeltaTime * direction * activeStats.movement.speed;
                    // or however you are incrementing the position
                if (currentValue >= verticalMax)
                {
                    direction *= -1;
                    currentValue = verticalMax;
                    if (Random.value < 0.70f)
                    {
                        changingColumns = true;
                        currentValue = transform.localPosition.x;
                        direction = Random.value < 0.50f ? 1 : -1;
                        return;
                    }
                }
                else if (currentValue <= verticalMin)
                {
                    direction *= -1;
                    currentValue = verticalMin;
                }
                transform.localPosition = new Vector3(transform.localPosition.x, currentValue, transform.localPosition.z);

            }
        }

        public void doHorizontalCycle()
        {
            currentValue += Time.deltaTime * direction * activeStats.movement.speed;
            // or however you are incrementing the position
            if (currentValue >= rightMax)
            {
                direction *= -1;
                currentValue = rightMax;
            }
            else if (currentValue <= leftMax)
            {
                direction *= -1;
                currentValue = leftMax;
            }
            transform.localPosition = new Vector3(currentValue, transform.localPosition.y, transform.localPosition.z);
            if (Random.value < 0.05f)
            {
                changingColumns = false;
                currentValue = transform.localPosition.y;
            }
        }
    }
}
