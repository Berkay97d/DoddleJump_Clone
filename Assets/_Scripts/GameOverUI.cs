using System;
using System.Collections;
using System.Collections.Generic;
using Players;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Transform _mainTransform;
    
    
    private void Start()
    {
        PlayerDeadChecker.Instance.OnPlayerDead += OnPlayerDead;
    }

    private void OnPlayerDead()
    {
        _mainTransform.gameObject.SetActive(true);
    }
}
