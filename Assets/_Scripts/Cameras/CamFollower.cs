using DG.Tweening;
using Players;
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
        }
    }
}
