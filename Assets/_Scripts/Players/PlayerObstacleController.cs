using System;
using UnityEngine;

namespace Players
{
    public class PlayerObstacleController : MonoBehaviour
    {
        [SerializeField] private PlayerBoostController _playerBoostController;
        [SerializeField] private PlayerDeadChecker _playerDeadChecker;
        [SerializeField] private PlayerJumper _playerJumper;
        [SerializeField] private Player _player;

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
        }
        

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Obstacle")) return;
            if (_playerBoostController.GetIsBoosted()) return;
            if (_player.GetRigidbody().velocity.y > 10) return;
                
            _playerDeadChecker.OnPlayerDeadInvoke();
        }
    }
}