using System;
using UnityEngine;

namespace Players
{
    public class PlayerChestCollisionController : MonoBehaviour
    {
        [SerializeField] private Player _player;


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out ChestCollisionController chestCollisionController)) return;

            Vector2 velocity = _player.GetRigidbody().velocity;

            if (velocity.y > 0)
            {
                _player.GetRigidbody().velocity = Vector2.zero;
            }
            else
            {
                const float jumpForce = 7.5f;
                _player.GetJumper().Jump(jumpForce);
            }
            
            const int damage = -1;
            chestCollisionController.GetChest().AddHealth(damage);
        }


        public Player GetPlayer()
        {
            return _player;
        }
    }
}