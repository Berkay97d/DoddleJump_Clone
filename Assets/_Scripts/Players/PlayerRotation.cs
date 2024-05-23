using UnityEngine;

namespace Players
{
    public class PlayerRotation : MonoBehaviour
    {
        private void Update()
        {
            HandleRotation();
        }

        private void HandleRotation()
        {
            var rotation = transform.rotation;
        
            if (PlayerProperties.Direction == PlayerDirection.Left)
            {
                rotation.y = -180;
                transform.rotation = rotation;
            }
            else
            {
                rotation.y = 0;
                transform.rotation = rotation;
            }
        }
        
    }
}
