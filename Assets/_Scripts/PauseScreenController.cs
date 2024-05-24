using System;
using UnityEngine;

public class PauseScreenController : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.SetCanPlay(false);
    }
    
    private void OnDisable()
    {
        GameManager.SetCanPlay(true);
    }
}