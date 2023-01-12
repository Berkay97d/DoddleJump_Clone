using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BluePlatform : Platform
{
    private enum Side
    {
        Left,Right      
    }
    private Side side;
    private void OnEnable()
    {
        if (transform.position.x < 0)
        {
            side = Side.Left;
        }
        else
        {
            side = Side.Right;
        }
    }

    [SerializeField] private float oscillationLimit ;

    private void Start()
    {
        Move();
    }

    private void Move()
    {
        var position = transform.position;
        if (side == Side.Left)
        {
            var target = new Vector3(oscillationLimit, transform.position.y, 0);
            var returnTarget = new Vector3(-oscillationLimit, transform.position.y, 0);
            
            transform.DOMoveX(target.x, 1f).SetSpeedBased().OnComplete(() =>
            {
                transform.DOMoveX(returnTarget.x,1f).SetSpeedBased().OnComplete(() =>
                {
                    transform.DOMoveX(position.x, 1f).SetSpeedBased().OnComplete(() =>
                    {
                        
                    });
                });
            }).SetLoops(-1);
        }
        else
        {
            var target = new Vector3(-oscillationLimit, transform.position.y, 0);
            var returnTarget = new Vector3(oscillationLimit, transform.position.y, 0);
            
            transform.DOMoveX(target.x, 1f).SetSpeedBased().OnComplete(() =>
            {
                transform.DOMoveX(returnTarget.x,1f).SetSpeedBased().OnComplete(() =>
                {
                    transform.DOMoveX(position.x, 1f).SetSpeedBased().OnComplete(() =>
                    {
                        
                    });
                });
            }).SetLoops(-1);
        }
    }
    
    
    
    
}
