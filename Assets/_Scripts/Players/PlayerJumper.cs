using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Players
{
    public class PlayerJumper : MonoBehaviour
    {
        [SerializeField] private Player _player;
        
        [FormerlySerializedAs("jumpForce")]
        [Header("Values")]
        [SerializeField] private float _jumpForce;
        
        public static event Action<float> OnJump; 

        private Rigidbody2D m_Rb;
        private float m_jumpForce;
    
        
        private void Awake()
        {
            m_Rb = GetComponent<Rigidbody2D>();
        }

    
        private void TryJump(float force)
        {
            if (!PlayerProperties.Instance.IsFalling())
            {
                return;
            }

            Jump(force);
        }

        
        public void Jump(float force)
        {
            Vector2 velocity = m_Rb.velocity;
            velocity.y = force;
            m_Rb.velocity = velocity;
            
            _player.SetCanDead(force <= _jumpForce);
            
            OnJump?.Invoke(force);
        }


        private void OnCollisionEnter2D(Collision2D col)
        {
             // if (m_jumpForce > 12) return;
            
            if (col.collider.CompareTag("Platform"))
            {
                TryJump(_jumpForce);
                m_jumpForce = _jumpForce;
                
                return;
            }
        
            if (col.collider.CompareTag("Jumper"))
            {
                TryJump(_jumpForce * 3);
                m_jumpForce = _jumpForce * 3;
                
                return;
            }

            if (col.collider.CompareTag("Spring"))
            {
                TryJump(_jumpForce * 1.75f);
                m_jumpForce = _jumpForce * 1.75f;
                
                return;
            }
        }
    }
}
