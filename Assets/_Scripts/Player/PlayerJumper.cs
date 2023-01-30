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

    private void Jump()
    {
        if (!PlayerProperties.Instance.IsFalling())
        {
            return;
        }
        
        var velocity = rb.velocity;
        velocity.y = jumpForce;
        rb.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Platform"))
        {
            Jump();
        }
    }
    
    
    
}
