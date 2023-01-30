using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundPool : MonoBehaviour
{
    private Queue<BackgroundController> backgrounds = new Queue<BackgroundController>();
    private Vector3 offset; 
    
    
    
    private void Awake()
    {
        var bgs = GetComponentsInChildren<BackgroundController>();

        foreach (var background in bgs)
        {
            backgrounds.Enqueue(background);
            background.Inject(this);
        }

        offset = bgs[1].transform.position - bgs[0].transform.position;
    }

    public void CycleBackground()
    {
        var bg = backgrounds.Dequeue();
        bg.transform.position += 3 * offset;
        bg.flag = false;
        bg.DestroyPlatform();
        bg.CreatePlatform();
        backgrounds.Enqueue(bg);
    }
}
