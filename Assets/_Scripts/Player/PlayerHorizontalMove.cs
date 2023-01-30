using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerHorizontalMove : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Application.isMobilePlatform)
        {
            MoveMobile();
        }
        else
        {
            MovePc();
        }
        
        
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

        
    }

    
}
