using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayAgainButton : MonoBehaviour
{
     [SerializeField] private Button _button;


     private void Awake()
     {
          _button.onClick.AddListener(() =>
          {
               SceneManager.LoadScene(0);
          });
     }

     private void OnDestroy()
     {
          _button.onClick.RemoveListener(() =>
          {
               SceneManager.LoadScene(0);
          });
     }
}
