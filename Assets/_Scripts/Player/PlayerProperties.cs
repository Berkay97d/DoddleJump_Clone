using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    #region Singleton

    public static PlayerProperties Instance;
    private void OnEnable()
    {
        Instance = this;
    }
    
    #endregion

    private Rigidbody2D rb;

    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    public bool IsFalling()
    {
        return rb.velocity.y < 0.1f;
    }

    
}
