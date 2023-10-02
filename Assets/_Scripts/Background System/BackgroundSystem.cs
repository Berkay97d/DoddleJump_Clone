using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSystem : MonoBehaviour
{
    [SerializeField] private Background[] _backgrounds;
    [SerializeField] private float _distanceBetweenBackgrounds;

    public event Action<Background> OnBackgroundMoved;
    

    private void Start()
    {
        foreach (var background in _backgrounds)
        {
            background.OnPlayerReached += OnPlayerReachedBackgroundMiddle;
        }
    }

    private void OnDestroy()
    {
        foreach (var background in _backgrounds)
        {
            background.OnPlayerReached -= OnPlayerReachedBackgroundMiddle;
        }
    }

    private void OnPlayerReachedBackgroundMiddle(Background background)
    {
        if (background.GetOrder() == 2)
        {
            var underestBackground = GetBackgroundByOrder(0);
            var middleBackground = GetBackgroundByOrder(1);
            var uppestBackground = GetBackgroundByOrder(2);
            
            MoveBackgroundUpper(underestBackground, uppestBackground);
            OnBackgroundMoved?.Invoke(underestBackground);
            
            underestBackground.SetOrder(2);
            middleBackground.SetOrder(0);
            uppestBackground.SetOrder(1);
        }
    }

    private Background GetBackgroundByOrder(int order)
    {
        foreach (var background in _backgrounds)
        {
            if (background.GetOrder() == order)
            {
                return background;
            }
        }

        return null;
    }

    private void MoveBackgroundUpper(Background targetBackground, Background underBackground)
    {
        var targetpos = new Vector3(
            targetBackground.transform.position.x,
            underBackground.transform.position.y + _distanceBetweenBackgrounds,
            targetBackground.transform.position.z
            );

        targetBackground.transform.position = targetpos;
    }
}
