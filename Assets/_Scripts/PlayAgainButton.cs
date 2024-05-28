using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayAgainButton : MonoBehaviour
{
     [SerializeField] private Button _button;


     private void Awake()
     {
          _button.onClick.AddListener(OnClicked);
     }
     
     private void OnDestroy()
     {
          _button.onClick.RemoveListener(OnClicked);
     }
     
     
     private static void OnClicked()
     {
          AudioManager.PlayButtonClickSound();

          SceneManager.LoadScene(0);
     }
}
