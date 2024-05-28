using Managers;
using UnityEngine;
using UnityEngine.UI;

public class ClosePopUpButton : MonoBehaviour
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private Transform _popUpMainTransform;
    
    
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
        PopUpMainSetActive(false);
        
        AudioManager.PlayButtonClickSound();
    }
    
    
    private void PopUpMainSetActive(bool active)
    {
        _popUpMainTransform.gameObject.SetActive(active);
    }
}