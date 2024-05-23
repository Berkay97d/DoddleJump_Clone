using UnityEngine;

namespace Player
{
    public class PlayerJumper : MonoBehaviour
    {
        [Header("Values")]
        [SerializeField] private float jumpForce;

        private Rigidbody2D m_Rb;
    
        
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
        }

        
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.collider.CompareTag("Platform"))
            {
                Jump(jumpForce);
            }
        
            if (col.collider.CompareTag("Jumper"))
            {
                Jump(jumpForce * 3);
            }

            if (col.collider.CompareTag("Spring"))
            {
                Jump(jumpForce * 1.75f);
            }
        }
    
    
    
    }
}
