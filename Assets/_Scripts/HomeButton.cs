using System;
using Managers;
using UnityEngine;
using UnityEngine.UI;

public class HomeButton : MonoBehaviour
{
    [SerializeField] private Transform _pauseScreenTransform;
    [SerializeField] private Button _homeButton;
    
    
    private void Awake()
    {
        _homeButton.onClick.AddListener(OnClicked);
    }

    private void OnDestroy()
    {
        _homeButton.onClick.RemoveListener(OnClicked);
    }


    private void OnClicked()
    {
        PauseScreenSetActive(!GetPauseScreenActiveSelf());
        
        AudioManager.PlayButtonClickSound();
    }

    
    private bool GetPauseScreenActiveSelf()
    {
        return _pauseScreenTransform.gameObject.activeSelf;
    }

    private void PauseScreenSetActive(bool active)
    {
        _pauseScreenTransform.gameObject.SetActive(active);
    }
}