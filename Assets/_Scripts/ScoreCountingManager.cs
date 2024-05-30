using System;
using TMPro;
using UnityEngine;

public class ScoreCountingManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    public static event Action<int> OnScoreChanged;

    private static ScoreCountingManager ms_Instance;

    private Camera m_MainCamera;
    private int m_Score;
    private int m_CoinScore;

    private void Awake()
    {
        ms_Instance = this;
        m_MainCamera = Camera.main;
    }

    private void Start()
    {
        UpdateScoreText();
    }

    private void Update()
    {
        Vector3 cameraPosition = m_MainCamera.transform.position;
        int cameraScore = Mathf.RoundToInt(cameraPosition.y * 22.5f);

        int totalScore = cameraScore + m_CoinScore;
        if (totalScore > m_Score)
        {
            m_Score = totalScore;
            UpdateScoreText();
        }
    }

    public static void AddScore(int amount)
    {
        ms_Instance.m_CoinScore += amount;
        ms_Instance.m_Score += amount; // Anında güncelleme için
        ms_Instance.UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        _scoreText.text = m_Score.ToString();
        OnScoreChanged?.Invoke(m_Score);
    }
}