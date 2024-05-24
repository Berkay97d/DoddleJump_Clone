using System;
using UnityEngine;

namespace Players
{
    public class PlayerObstacleController : MonoBehaviour
    {
        [SerializeField] private PlayerBoostController _playerBoostController;
        [SerializeField] private PlayerDeadChecker _playerDeadChecker;
        [SerializeField] private PlayerJumper _playerJumper;

        private float m_LastJumpForce = 12f;

        private void Awake()
        {
            PlayerJumper.OnJump += OnJump;
        }
        
        private void OnDestroy()
        {
            PlayerJumper.OnJump -= OnJump;
        }
        
        
        private void OnJump(float force)
        {
            m_LastJumpForce = force;
            
            Debug.Log(m_LastJumpForce);
        }
        

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Obstacle")) return;
            if (_playerBoostController.GetIsBoosted()) return;
            if (m_LastJumpForce > 12) return;
                
            _playerDeadChecker.OnPlayerDeadInvoke();
        }
    }
}