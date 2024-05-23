using DG.Tweening;
using Player;
using UnityEngine;

namespace Cameras
{
    public class CamFollower : MonoBehaviour
    {
        [SerializeField] private int _deadCamMoveSize;
        [SerializeField] private float _deadMoveDuration;

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

            var position = transform.position;
            position.y = PlayerProperties.HighestWidth;
            transform.position = position;
        }
    
        private void OnPlayerDead()
        {
            m_ShouldFollow = false;
            DeadMove();
        }

        private void DeadMove()
        {
            var newPos = new Vector3(transform.position.x, transform.position.y - _deadCamMoveSize, transform.position.z);

            transform.DOMove(newPos, _deadMoveDuration);
        }
    
    }
}
