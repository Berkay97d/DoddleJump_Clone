using System;
using System.Globalization;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    
    public static event Action<int> OnScoreChanged; 
    
    private Camera m_MainCamera;
    private int m_Score;

    private void Awake()
    {
        m_MainCamera = Camera.main;
    }


    private void Update()
    {
        Vector3 cameraPosition = m_MainCamera.transform.position;
        m_Score = Mathf.RoundToInt(cameraPosition.y * 22.5f);
        
        _scoreText.text = m_Score.ToString();
        
        OnScoreChanged?.Invoke(m_Score);
    }
}