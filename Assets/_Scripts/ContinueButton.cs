using System;
using Managers;
using UnityEngine;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour
{
    [SerializeField] private Button _continueButton;
    [SerializeField] private Transform _pauseScreenTransform;


    private void Awake()
    {
        _continueButton.onClick.AddListener(OnClicked);
    }
    
    private void OnDestroy()
    {
        _continueButton.onClick.RemoveListener(OnClicked);
    }
    
    
    private void OnClicked()
    {
        PauseScreenSetActive(false);
        
        AudioManager.PlayButtonClickSound();
    }

    private void PauseScreenSetActive(bool active)
    {
        _pauseScreenTransform.gameObject.SetActive(active);
    }
}