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

            const int damage = -1;
            const int score = 125;
            
            if (_player.GetPlayerBoostController().GetIsBoosted())
            {
                chestCollisionController.GetChest().AddHealth(damage * 3);
                ScoreCountingManager.AddScore(score * 3);
                
                return;
            }

            
            Vector2 velocity = _player.GetRigidbody().velocity;
            
            switch (velocity.y)
            {
                case > 11:
                {
                    chestCollisionController.GetChest().AddHealth(damage * 3);
                    ScoreCountingManager.AddScore(score * 3);
                
                    return;
                }
                case > 0:
                {
                    _player.GetRigidbody().velocity = new Vector2(0f, 3f);
                    break;
                }
                default:
                {
                    const float jumpForce = 7.5f;
                    _player.GetJumper().Jump(jumpForce);
                    break;
                }
            }


            chestCollisionController.GetChest().AddHealth(damage);
            
            ScoreCountingManager.AddScore(score);
        }


        public Player GetPlayer()
        {
            return _player;
        }
    }
}