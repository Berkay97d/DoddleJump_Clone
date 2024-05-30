using UnityEngine;

namespace DefaultNamespace
{
    public class CameraController : MonoBehaviour
    {
        public SpriteRenderer rink;

        private void Update()
        {
            float screenAspect = (float)Screen.width / (float)Screen.height;
            float targetAspect = rink.bounds.size.x / rink.bounds.size.y;

            if (screenAspect >= targetAspect)
            {
                Camera.main.orthographicSize = rink.bounds.size.y / 2;
            }
            else
            {
                float differenceInSize = targetAspect / screenAspect;
                Camera.main.orthographicSize = rink.bounds.size.y / 2 * differenceInSize;
            }
        }
    }
}