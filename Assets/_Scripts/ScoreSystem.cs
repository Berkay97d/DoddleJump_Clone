using System;
using Player;
using UnityEngine;

namespace _Scripts
{
    public class ScoreSystem : MonoBehaviour
    {
        private readonly string m_HighScoreKey = "PlayerScore";
        private float m_CurrentScore = 0;

        private void Start()
        {
            PlayerDeadChecker.Instance.OnPlayerDead += OnPlayerDead;
        }

        private void OnDestroy()
        {
            PlayerDeadChecker.Instance.OnPlayerDead -= OnPlayerDead;
        }

        private void OnPlayerDead()
        {
            m_CurrentScore = (PlayerProperties.Instance.GetHighestWidth() * 100);
        }

        private void SaveHighScore(int currentScore)
        {
            if (currentScore >GetHighScore())
            {
                PlayerPrefs.SetFloat(m_HighScoreKey, currentScore);
                PlayerPrefs.Save(); 
                Debug.Log("Score saved: " + currentScore);
            }
        }
        
        private float GetHighScore()
        {
            var loadedScore = PlayerPrefs.GetFloat(m_HighScoreKey, 0f); // Varsayılan olarak 0 kullanılır, eğer kaydedilmiş bir skor yoksa.
            Debug.Log("Score loaded: " + loadedScore);
            return loadedScore;
        }
    }
}