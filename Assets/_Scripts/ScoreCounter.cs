using System;
using System.Globalization;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    
    private Camera m_MainCamera;

    private void Awake()
    {
        m_MainCamera = Camera.main;
    }


    private void Update()
    {
        _scoreText.text = Mathf.Round(m_MainCamera.transform.position.y * 22.5f).ToString(CultureInfo.InvariantCulture);
    }
}