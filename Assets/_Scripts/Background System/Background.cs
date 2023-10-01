using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.Background_System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Background : MonoBehaviour
{
    [SerializeField] private int _order;
    
    public event Action<Background> OnPlayerReached;
    
    private BackgroundMiddlePoint m_BackgroundMiddlePoint;


    private void Awake()
    {
        m_BackgroundMiddlePoint = GetComponentInChildren<BackgroundMiddlePoint>();
    }

    private void Start()
    {
        m_BackgroundMiddlePoint.OnPlayerReached += OnPlayerReachedMiddlePoint;
    }

    private void OnDestroy()
    {
        m_BackgroundMiddlePoint.OnPlayerReached -= OnPlayerReachedMiddlePoint;
    }

    private void OnPlayerReachedMiddlePoint()
    {
        OnPlayerReached?.Invoke(this);
    }

    public void SetOrder(int order)
    {
        _order = order;
    }

    public int GetOrder()
    {
        return _order;
    }

}
