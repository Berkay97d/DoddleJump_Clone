using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BluePlatform : Platform
{
    
    [SerializeField] private float xLimit ;
    [SerializeField] private float speed;
    private Vector3 left, right;
    
    private void Start()
    {
        DefinePositions();
        Move();
    }

    private void Move()
    {
        if (transform.position.x < 0)
        {
            transform.DOMove(right, speed).SetSpeedBased().OnComplete(() =>
            {
                Move();
            });
        }
        else
        {
            transform.DOMove(left, speed).SetSpeedBased().OnComplete(() =>
            {
                Move();
            });
        }
    }

    private void DefinePositions()
    {
        var position = transform.position;
        left = new Vector3(-xLimit, position.y, position.z);
        right = new Vector3(xLimit, position.y, position.z);
    }
    
    
    
    
}
