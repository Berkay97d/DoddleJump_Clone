using System;
using Managers;
using UnityEngine;
using UnityEngine.Serialization;

namespace Players
{
    public class PlayerHorizontalMove : MonoBehaviour
    {
        [FormerlySerializedAs("speed")] [SerializeField] private float _speed;
    
        private float m_LeftInput;
        private float m_RightInput;
        private bool m_CanChangeInput;


        private void Awake()
        {
            TouchInputManager.OnWorldPositionChanged += OnWorldPositionChanged;
            TouchInputManager.OnTouchEnded += OnTouchEnded;
        }

        private void OnDestroy()
        {
            TouchInputManager.OnWorldPositionChanged -= OnWorldPositionChanged;
            TouchInputManager.OnTouchEnded -= OnTouchEnded;
        }
    
    
        private void OnTouchEnded()
        {
            m_LeftInput = 0;
            m_RightInput = 0;
        }

        private void OnWorldPositionChanged(Vector2 position)
        {
            if (position == Vector2.zero) return;
            if (!m_CanChangeInput) return;
        
            Vector2 playerPos = transform.position;
            Vector2 touchWorldPos = TouchInputManager.GetWorldPosition();

            if (playerPos.x > touchWorldPos.x)
            {
                m_LeftInput = -1;
                m_RightInput = 0;
            }
            else if (playerPos.x < touchWorldPos.x)
            {
                m_RightInput = 1;
                m_LeftInput = 0;
            }
        }

        private void Update()
        {
            TryMove();
        }

        private void TryMove()
        {
            if (!GameManager.GetCanPlay()) return;

            Camera mainCamera = Camera.main;
            if (mainCamera == null) return;

            float screenWidth = 2f * mainCamera.orthographicSize * mainCamera.aspect;
            float normalizedX = TouchInputManager.GetWorldPosition().x / (screenWidth / 2f);

            float screenMovementLimitLine = 0.910f;

            Debug.Log(Mathf.Abs(normalizedX));
            
            if (Mathf.Abs(normalizedX) < screenMovementLimitLine)
            {
                if (Mathf.Abs(transform.position.x - TouchInputManager.GetWorldPosition().x) > 0.05f)
                {
                    Move();
                    m_CanChangeInput = true;
                    return;
                }

                return;
            }

            m_CanChangeInput = false;
            Move();
        }



        private void Move()
        {
            float playerInput = m_LeftInput + m_RightInput;
        
            Vector3 position = transform.position;
            
            position.x += playerInput * _speed * Time.deltaTime;

            PlayerProperties.Direction = playerInput switch
            {
                < 0 => PlayerDirection.Left, 
                > 0 => PlayerDirection.Right,
                _ => PlayerProperties.Direction
            };
        
            transform.position = position;
        }
    }
}

    

