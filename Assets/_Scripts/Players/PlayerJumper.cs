using System;
using UnityEngine;

namespace Players
{
    public class PlayerJumper : MonoBehaviour
    {
        [Header("Values")]
        [SerializeField] private float jumpForce;
        
        public static event Action<float> OnJump; 

        private Rigidbody2D m_Rb;
        private float m_jumpForce;
    
        
        private void Awake()
        {
            m_Rb = GetComponent<Rigidbody2D>();
        }

    
        private void Jump(float force)
        {
            if (!PlayerProperties.Instance.IsFalling())
            {
                return;
            }
        
            Vector2 velocity = m_Rb.velocity;
            velocity.y = force;
            m_Rb.velocity = velocity;
            
            OnJump?.Invoke(force);
        }

        
        private void OnCollisionEnter2D(Collision2D col)
        {
             // if (m_jumpForce > 12) return;
            
            if (col.collider.CompareTag("Platform"))
            {
                Jump(jumpForce);
                m_jumpForce = jumpForce;
                
                return;
            }
        
            if (col.collider.CompareTag("Jumper"))
            {
                Jump(jumpForce * 3);
                m_jumpForce = jumpForce * 3;
                
                return;
            }

            if (col.collider.CompareTag("Spring"))
            {
                Jump(jumpForce * 1.75f);
                m_jumpForce = jumpForce * 1.75f;
                
                return;
            }
        }
    }
}
