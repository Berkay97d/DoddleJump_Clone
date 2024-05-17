using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;


public class PlayerHorizontalMove : MonoBehaviour
{
    [FormerlySerializedAs("speed")] [SerializeField] private float _speed;
    
    private float m_LeftInput;
    private float m_RightInput;


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
        Debug.Log("Touch Ended");
    }

    private void OnWorldPositionChanged(Vector2 position)
    {
        if (position == Vector2.zero) return;
        
        Vector2 playerPos = transform.position;
        Vector2 touchWorldPos = TouchInputManager.GetWorldPosition();

        if (playerPos.x > touchWorldPos.x)
        {
            m_LeftInput = -1;
            m_RightInput = 0;
            Debug.Log("Left");
        }
        else if (playerPos.x < touchWorldPos.x)
        {
            m_RightInput = 1;
            m_LeftInput = 0;
            Debug.Log("Right");
        }
    }

    private void Update()
    {
        TryMove();
    }

    private bool TryMove()
    {
        if (Math.Abs(transform.position.x - TouchInputManager.GetWorldPosition().x) < 0.1f) return false;

        Move();
        
        return true;
    }

    private void Move()
    {
        float playerInput = m_LeftInput + m_RightInput;

        if (playerInput == 0) return;
        
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

    

