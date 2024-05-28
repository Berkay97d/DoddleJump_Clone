using System;
using Managers;
using UnityEngine;
using UnityEngine.UI;

public class EndGameButton : MonoBehaviour
{
    [SerializeField] private Button _endGameButton;


    private void Awake()
    {
        _endGameButton.onClick.AddListener(OnClicked);
    }

    private void OnDestroy()
    {
        _endGameButton.onClick.RemoveListener(OnClicked);
    }


    private void OnClicked()
    {
        Debug.Log("End Game!");
        
        AudioManager.PlayButtonClickSound();
        Application.Quit();
    }
}