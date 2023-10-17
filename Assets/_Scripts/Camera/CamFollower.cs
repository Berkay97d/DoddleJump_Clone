using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CamFollower : MonoBehaviour
{
    [SerializeField] private int _deadCamMoveSize;
    [SerializeField] private float _deadMoveDuration;

    private bool shouldFollow = true;

    private void Start()
    {
        PlayerDeadChecker.Instance.OnPlayerDead += OnPlayerDead;
    }
    
    private void LateUpdate()
    {
        if (!shouldFollow)
        {
            return;
        }

        var position = transform.position;
        position.y = PlayerProperties.HighestWidth;
        transform.position = position;
    }
    
    private void OnPlayerDead()
    {
        shouldFollow = false;
        DeadMove();
    }

    private void DeadMove()
    {
        var newPos = new Vector3(transform.position.x, transform.position.y - _deadCamMoveSize, transform.position.z);

        transform.DOMove(newPos, _deadMoveDuration);
    }
    
}
