using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private List<PlatformGroup> _platformGroups;
    
    public bool _flag = false;
    
    private PlatformGroup m_MyPlatformGroup;
    private BackgroundPool m_BackgroundPool;
    

    private void Start()
    {
        CreatePlatform();
    }

    public void CreatePlatform()
    {
        var randomNum = Random.Range(0, _platformGroups.Count);
        m_MyPlatformGroup = Instantiate(_platformGroups[randomNum], transform.position, Quaternion.identity);
    }

    public void DestroyPlatform()
    {
        Destroy(m_MyPlatformGroup.gameObject);
    }
    
    public void Inject(BackgroundPool bgPool)
    {
        m_BackgroundPool = bgPool;
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !_flag)
        {
            m_BackgroundPool.CycleBackground();
            _flag = true;
        } 
    }
    
    
}
