using System.Collections;
using DG.Tweening;
using Managers;
using UnityEngine;

public class PopUpController : MonoBehaviour
{
    [SerializeField] private Transform _popUpMainTransform;
    [SerializeField] private int _scoreToPopUp;
    [SerializeField] private float _popUpDuration;
    [SerializeField] private Transform _inScreenTransform;
    [SerializeField] private Transform _outScreenTransform;

    private bool m_IsAlreadyShowed = false;

    private void Awake()
    {
        ScoreCountingManager.OnScoreChanged += OnScoreChanged;
    }

    private void OnDestroy()
    {
        ScoreCountingManager.OnScoreChanged -= OnScoreChanged;
    }

    
    private void OnScoreChanged(int obj)
    {
        return;
        
        /*
        if (obj < _scoreToPopUp || m_IsAlreadyShowed) return;

        m_IsAlreadyShowed = true;
        PopUpMainSetActive(true);
        
        _popUpMainTransform.DOMove(_inScreenTransform.position, 0.5f).SetEase(Ease.OutBounce);
        
        AudioManager.PlayWinPopUpSound();
        StartCoroutine(AutoDeactivatePopUp());
        */
    }

    
    private void PopUpMainSetActive(bool active)
    {
        _popUpMainTransform.gameObject.SetActive(active);
    }

    private bool GetPopUpMainActiveSelf()
    {
        return _popUpMainTransform.gameObject.activeSelf;
    }

    private IEnumerator AutoDeactivatePopUp()
    {
        yield return new WaitForSeconds(_popUpDuration);
        
        _popUpMainTransform.DOMoveY(_outScreenTransform.position.y, 0.5f).SetEase(Ease.OutBounce);
    }
}