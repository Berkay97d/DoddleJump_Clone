using System;
using Managers;
using UnityEngine;
using UnityEngine.UI;

public class AudioButton : MonoBehaviour
{
    [SerializeField] private Button _audioButton;
    [SerializeField] private Image _audioImage;
    [SerializeField] private Sprite _audioActiveSprite;
    [SerializeField] private Sprite _audioInactiveSprite;


    private void Awake()
    {
        _audioButton.onClick.AddListener(OnClicked);
    }

    private void OnDestroy()
    {
        _audioButton.onClick.RemoveListener(OnClicked);
    }


    private void OnClicked()
    {
        float volume = AudioListener.volume;

        AudioListener.volume = Math.Abs(volume - 1) < 0.1f ? 0 : 1;
        
        UpdateAudioImage(volume);
        AudioManager.PlayButtonClickSound();
    }

    
    private void UpdateAudioImage(float volume)
    {
        _audioImage.sprite = Math.Abs(volume - 1) < 0.1f ? _audioInactiveSprite : _audioActiveSprite;
    }
}