using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class PlayerHorizontalMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private DoddleButton leftButton;
    [SerializeField] private DoddleButton rightButton;
    
    private float leftInput = 0;
    private float rightInput = 0;


    private void Start()
    {
        leftButton.onDown += OnLeftDown;
        leftButton.onUp += OnLeftUp;
        
        rightButton.onDown += OnRightDown;
        rightButton.onUp += OnRightUp;
    }

    private void OnRightUp()
    {
        rightInput = 0;
    }

    private void OnRightDown()
    {
        rightInput = 1;
    }

    private void OnLeftUp()
    {
        leftInput = 0;
    }

    private void OnLeftDown()
    {
        leftInput = -1;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        MoveKaraca();
        
        
        void MoveMobile()
        {
            Vector3 dir = Vector3.zero;

            // we assume that device is held parallel to the ground
            // and Home button is in the right hand

            // remap device acceleration axis to game coordinates:
            //  1) XY plane of the device is mapped onto XZ plane
            //  2) rotated 90 degrees around Y axis
            dir.x = Input.acceleration.x;
            //dir.z = Input.acceleration.x;

            // clamp acceleration vector to unit sphere
            if (dir.sqrMagnitude > 1)
                dir.Normalize();

            // Make it move 10 meters per second instead of 10 meters per frame...
            dir *= Time.deltaTime;

            // Handle rotation
            if (dir.x < 0)
            {
                PlayerProperties.Direction = PlayerDirection.Left;
            }
            else if (dir.x > 0)
            {
                PlayerProperties.Direction = PlayerDirection.Right;
            }
            
            // Move object
            transform.Translate(dir * speed * 2);
        }

        void MovePc()
        {
            var position = transform.position; 
            var playerInput = Input.GetAxis("Horizontal");
            
            position.x += playerInput * speed * Time.deltaTime;
            
            if (playerInput < 0)
            {
                PlayerProperties.Direction = PlayerDirection.Left;
            }
            else if (playerInput > 0)
            {
                PlayerProperties.Direction = PlayerDirection.Right;
            }
            
            
            transform.position = position;
        }

        void MoveKaraca()
        {
            var position = transform.position;
            var playerInput = leftInput+rightInput;
            
            position.x += playerInput * speed * Time.deltaTime;
            
            if (playerInput < 0)
            {
                PlayerProperties.Direction = PlayerDirection.Left;
            }
            else if (playerInput > 0)
            {
                PlayerProperties.Direction = PlayerDirection.Right;
            }
            
            
            transform.position = position;
        }
    }
    
    
    
}

    

