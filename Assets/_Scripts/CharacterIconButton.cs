using System;
using Managers;
using ScriptableObjects.CharacterVisuals;
using UnityEngine;
using UnityEngine.UI;

public class CharacterIconButton : MonoBehaviour
{
    [SerializeField] private Transform _characterVisualsParent;
    [SerializeField] private CharacterVisualSO _characterVisual;
    [SerializeField] private Button _button;
    [SerializeField] private float _fadeDuration = 0.5f;
    [SerializeField] private Image _fadeImage;

    private void Awake()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        if (GameManager.GetCharacterVisual()) return;

        //FadeOutAndDisable().Forget();
    }

    /*
    private async UniTask FadeOutAndDisable()
    {
        await FadeOut();

        CharacterVisualsParentSetActive(false);
        GameManager.SetCharacterVisual(_characterVisual);
        GameManager.SetCanPlay(true);

        AudioManager.PlayButtonClickSound();
    }

    private async UniTask FadeOut()
    {
        Color startColor = _fadeImage.color;
        float elapsed = 0f;

        while (elapsed < _fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, elapsed / _fadeDuration);
            _fadeImage.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            await UniTask.Yield();
        }

        _fadeImage.color = new Color(startColor.r, startColor.g, startColor.b, 0);
    }

    private void CharacterVisualsParentSetActive(bool active)
    {
        _characterVisualsParent.gameObject.SetActive(active);
    }*/
}