using UnityEngine;

namespace DefaultNamespace
{
    public class CameraController : MonoBehaviour
    {
        public SpriteRenderer rink;

        private void Update()
        {
            float screenAspect = (float)Screen.width / (float)Screen.height;
            float targetWidth = rink.bounds.size.x;

            Camera.main.orthographicSize = targetWidth / (2 * screenAspect);
        }
    }
}