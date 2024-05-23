using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StartScreenFade : MonoBehaviour
{
    [SerializeField] private Image _startScreenImage;
    [SerializeField] private float _fadeDuration;
    [SerializeField] private Transform _startScreenMainTransform;

    private void Start()
    {
        FadeOut();
    }

    private void FadeOut()
    {
        _startScreenImage.DOFade(0, _fadeDuration).OnComplete(() =>
        {
            StartScreenMainTransformSetActive(false);
        });
    }

    private void StartScreenMainTransformSetActive(bool active)
    {
        _startScreenMainTransform.gameObject.SetActive(active);
    }
}