using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollower : MonoBehaviour
{
    [SerializeField] private float followOffset;
    private void LateUpdate()
    {
        var position = transform.position;
        position.y = PlayerProperties.HighestWidth + followOffset;
        transform.position = position;
    }
    
    
}
