using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private List<PlatformGroup> platformGroups;
    private PlatformGroup myPlatformGroup;
    private BackgroundPool backgroundPool;
    public bool flag = false;
    

    private void Start()
    {
        CreatePlatform();
    }

    public void CreatePlatform()
    {
        var randomNum = Random.Range(0, platformGroups.Count);
        myPlatformGroup = Instantiate(platformGroups[randomNum], transform.position, Quaternion.identity);
    }

    public void DestroyPlatform()
    {
        Destroy(myPlatformGroup.gameObject);
    }
    
    public void Inject(BackgroundPool bgPool)
    {
        backgroundPool = bgPool;
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !flag)
        {
            backgroundPool.CycleBackground();
            flag = true;
        } 
    }
    
    
}
