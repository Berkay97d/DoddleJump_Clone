using DG.Tweening;
using Players;
using UnityEngine;

namespace Cameras
{
    public class CamFollower : MonoBehaviour
    {
        [SerializeField] private Transform _targetTransform;

        private bool m_ShouldFollow = true;

        
        private void Start()
        {
            PlayerDeadChecker.Instance.OnPlayerDead += OnPlayerDead;
        }
    
        private void LateUpdate()
        {
            if (!m_ShouldFollow)
            {
                return;
            }

            if (_targetTransform.position.y > transform.position.y)
            {
                Vector3 newPos = new Vector3(transform.position.x, _targetTransform.position.y, transform.position.z);
                transform.position = newPos;
            }
        }
    
        
        private void OnPlayerDead()
        {
            m_ShouldFollow = false;
        }
    }
}
