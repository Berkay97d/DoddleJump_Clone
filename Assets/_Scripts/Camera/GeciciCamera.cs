using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeciciCamera : MonoBehaviour
{
    [SerializeField] private Transform target;


    private void LateUpdate()
    {
        var position = transform.position;
        position.y = target.position.y + 2;
        transform.position = position;
    }
}
