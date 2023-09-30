using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BluePlatform : Platform
{
    
    [SerializeField] private float _xLimit ;
    [SerializeField] private float _speed;
    
    private Vector3 m_Left, m_Right;
    
    
    private void Start()
    {
        DefinePositions();
        Move();
    }

    private void Move()
    {
        if (transform.position.x < 0)
        {
            transform.DOLocalMove(m_Right, _speed).SetSpeedBased().OnComplete(Move);
        }
        else
        {
            transform.DOLocalMove(m_Left, _speed).SetSpeedBased().OnComplete(Move);
        }
    }

    private void DefinePositions()
    {
        var position = transform.localPosition;
        m_Left = new Vector3(-_xLimit, position.y, position.z);
        m_Right = new Vector3(_xLimit, position.y, position.z);
    }
    
    
    
    
}
