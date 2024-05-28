using DG.Tweening;
using Managers;
using UnityEngine;
using UnityEngine.UI;

public class ClosePopUpButton : MonoBehaviour
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private Transform _popUpMainTransform;
    [SerializeField] private Transform _outScreenTransform;
    
    
    private void Awake()
    {
        _closeButton.onClick.AddListener(OnClicked);
    }
    
    private void OnDestroy()
    {
        _closeButton.onClick.RemoveListener(OnClicked);
    }
    
    
    private void OnClicked()
    {
        PopUpMainSetActive();
        
        AudioManager.PlayButtonClickSound();
    }
    
    
    private void PopUpMainSetActive()
    {
        _popUpMainTransform.DOMoveY(_outScreenTransform.position.y, 0.5f).SetEase(Ease.OutBounce);
    }
}