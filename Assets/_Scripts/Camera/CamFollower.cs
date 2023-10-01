using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollower : MonoBehaviour
{
    
    private void LateUpdate()
    {
        var position = transform.position;
        position.y = PlayerProperties.HighestWidth;
        transform.position = position;
    }
    
    
}
