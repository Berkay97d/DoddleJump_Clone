using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    [SerializeField] private float xLim;
    [SerializeField] private float tpPos;


    private void Update()
    {
        Teleport();
    }

    private void Teleport()
    {
        if (transform.position.x > xLim)
        {
            var position = transform.position;
            position.x = -tpPos;
            transform.position = position;
        }
        else if (transform.position.x < -xLim)
        {
            var position = transform.position;
            position.x = tpPos;
            transform.position = position;
        }
    }
}
