using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playagain : MonoBehaviour
{
     private Button m_button;


     private void Start()
     {
          m_button = GetComponent<Button>();
          
          m_button.onClick.AddListener(() =>
          {
               SceneManager.LoadScene(0);
          });
     }
}
