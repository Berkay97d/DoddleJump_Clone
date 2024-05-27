using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class FPSDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _fpsText;
    
    private float m_DeltaTime;

    
    private void Update()
    {
        m_DeltaTime += (Time.unscaledDeltaTime - m_DeltaTime) * 0.1f;
        float fps = 1.0f / m_DeltaTime;
        _fpsText.text = "FPS: " + Mathf.Round(fps);
        
        
        switch (fps)
        {
            case >= 60:
                _fpsText.color = Color.green;
                break;
            case <= 30:
                _fpsText.color = Color.red;
                break;
            default:
            {
                float t = (fps - 30) / 30.0f;
                _fpsText.color = Color.Lerp(Color.red, Color.green, t);
                break;
            }
        }
    }
}