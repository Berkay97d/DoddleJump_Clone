using Player;
using UnityEngine;

namespace Platforms
{
    public class Platform : MonoBehaviour
    {
        private void Update()
        {
            if (transform.position.y + 5.5 < PlayerProperties.Instance.transform.position.y)
            {
                Destroy(gameObject);        
            }
        }

    
    }
}
