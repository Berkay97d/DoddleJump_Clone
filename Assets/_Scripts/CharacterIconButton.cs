using System;
using Managers;
using ScriptableObjects.CharacterVisuals;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

public class CharacterIconButton : MonoBehaviour
{
    [SerializeField] private Transform _characterVisualsParent;
    [SerializeField] private CharacterVisualSO _characterVisual;
    [SerializeField] private Button _button;
    [SerializeField] private float _fadeDuration;
    [SerializeField] private CanvasGroup _fadeCanvasGroup;

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

        FadeOutAndDisable().Forget();
    }

    private async UniTask FadeOutAndDisable()
    {

        CharacterVisualsParentSetActive(false);
        GameManager.SetCharacterVisual(_characterVisual);
        GameManager.SetCanPlay(true);

        AudioManager.PlayButtonClickSound();
        
        await FadeOut();
    }

    private async UniTask FadeOut()
    {
        float startAlpha = _fadeCanvasGroup.alpha;
        float elapsed = 0f;

        while (elapsed < _fadeDuration)
        {
            elapsed += Time.deltaTime;
            _fadeCanvasGroup.alpha = Mathf.Lerp(startAlpha, 0, elapsed / _fadeDuration);
            await UniTask.Yield();
        }

        _fadeCanvasGroup.alpha = 0;
    }

    private void CharacterVisualsParentSetActive(bool active)
    {
        _characterVisualsParent.gameObject.SetActive(active);
    }
}