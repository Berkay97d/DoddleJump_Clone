using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundPool : MonoBehaviour
{
    private readonly Queue<BackgroundController> m_Backgrounds = new Queue<BackgroundController>();
    private Vector3 m_Offset; 
    
    private void Awake()
    {
        var bgs = GetComponentsInChildren<BackgroundController>();

        foreach (var background in bgs)
        {
            m_Backgrounds.Enqueue(background);
            background.Inject(this);
        }

        m_Offset = bgs[1].transform.position - bgs[0].transform.position;
    }

    public void CycleBackground()
    {
        var bg = m_Backgrounds.Dequeue();
        bg.transform.position += 3 * m_Offset;
        bg._flag = false;
        bg.DestroyPlatform();
        bg.CreatePlatform();
        m_Backgrounds.Enqueue(bg);
    }
}
