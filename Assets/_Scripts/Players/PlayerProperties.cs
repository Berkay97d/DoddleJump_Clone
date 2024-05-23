using UnityEngine;

namespace Players
{
    public enum PlayerDirection{
        Left,
        Right
    }

    public class PlayerProperties : MonoBehaviour
    {
        public static PlayerProperties Instance;
        public static PlayerDirection Direction;
        public static float HighestWidth { get; private set; }
        [SerializeField] private Rigidbody2D rb;
    
    
        private void OnEnable()
        {
            Instance = this;
            Direction = PlayerDirection.Right;
            HighestWidth = transform.position.y;
        }

        private void Update()
        {
            UpdateHighestWidth();
        }

        public bool IsFalling()
        {
            return rb.velocity.y < 0.1f;
        }

        private void UpdateHighestWidth()
        {
            if (transform.position.y > HighestWidth)
            {
                HighestWidth = transform.position.y;
            }
        }

        public float GetHighestWidth()
        {
            return HighestWidth;
        }
    }
}