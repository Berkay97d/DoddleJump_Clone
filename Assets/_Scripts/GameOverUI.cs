using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Transform _mainTransform;
    
    
    private void Start()
    {
        PlayerDeadChecker.Instance.OnPlayerDead += OnPlayeDead;
    }

    private void OnPlayeDead()
    {
        var newPos = new Vector3(transform.position.x, PlayerProperties.HighestWidth - 20, transform.position.z);
        _mainTransform.position = newPos;
        
        _mainTransform.gameObject.SetActive(true);
    }
}
