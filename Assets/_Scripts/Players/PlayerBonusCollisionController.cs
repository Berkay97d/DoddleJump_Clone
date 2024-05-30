using System;
using UnityEngine;

namespace Players
{
    public class PlayerBonusCollisionController : MonoBehaviour
    {
        [SerializeField] private Player _player;


        private void OnTriggerEnter2D(Collider2D other)
        {
            TryChest(other);
            TryCoin(other);
        }

        private void TryCoin(Collider2D other)
        {
            if (!other.TryGetComponent(out CoinCollisionController coinCollisionController)) return;
            
            coinCollisionController.GetCoin().DestroySelf();

            ScoreCountingManager.AddScore(100);
        }

        private void TryChest(Collider2D other)
        {
            if (!other.TryGetComponent(out ChestCollisionController chestCollisionController)) return;

            Vector2 velocity = _player.GetRigidbody().velocity;

            if (velocity.y > 0)
            {
                _player.GetRigidbody().velocity = new Vector2(0f, 3f);
            }
            else
            {
                const float jumpForce = 7.5f;
                _player.GetJumper().Jump(jumpForce);
            }
            
            const int damage = -1;
            chestCollisionController.GetChest().AddHealth(damage);
            
            ScoreCountingManager.AddScore(250);
        }


        public Player GetPlayer()
        {
            return _player;
        }
    }
}