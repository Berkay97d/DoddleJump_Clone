using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumper : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private float jumpForce;

    private Rigidbody2D rb;
    
    
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    private void Jump(float force)
    {
        if (!PlayerProperties.Instance.IsFalling())
        {
            return;
        }
        
        var velocity = rb.velocity;
        velocity.y = force;
        rb.velocity = velocity;
    }

    
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Platform"))
        {
            Jump(jumpForce);
        }
        
        if (col.collider.CompareTag("Jumper"))
        {
            Jump(jumpForce*3);
        }

        if (col.collider.CompareTag("Spring"))
        {
            Jump(jumpForce*1.75f);
        }
    }
    
    
    
}
