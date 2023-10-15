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
    [SerializeField] private PlatformGroup _backgroundPlatformGroup;
    
    
    public event Action<Background> OnPlayerReached;
    
    private BackgroundMiddlePoint m_BackgroundMiddlePoint;


    private void Awake()
    {
        m_BackgroundMiddlePoint = GetComponentInChildren<BackgroundMiddlePoint>();
    }

    private void Start()
    {
        m_BackgroundMiddlePoint.OnPlayerReached += OnPlayerReachedMiddlePoint;
        
        // InitPlatformGroup();
    }

    private void OnDestroy()
    {
        m_BackgroundMiddlePoint.OnPlayerReached -= OnPlayerReachedMiddlePoint;
    }

    private void OnPlayerReachedMiddlePoint()
    {
        OnPlayerReached?.Invoke(this);
    }

    private void InitPlatformGroup(PlatformGroup platformGroup)
    {
        var newBackgroundPlatformGroup = Instantiate(platformGroup);
        newBackgroundPlatformGroup.transform.position = transform.position;

        _backgroundPlatformGroup = newBackgroundPlatformGroup;
    }
    
    private void InitNewPlatformGroup(PlatformGroup platformGroup)
    {
        Destroy(_backgroundPlatformGroup.gameObject);

        var newBackgroundPlatformGroup = Instantiate(platformGroup);
        newBackgroundPlatformGroup.transform.position = transform.position;

        _backgroundPlatformGroup = newBackgroundPlatformGroup;
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
