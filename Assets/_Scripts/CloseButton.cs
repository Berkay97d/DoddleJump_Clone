using UnityEngine;
using UnityEngine.UI;

public class CloseButton : MonoBehaviour
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private Transform _pauseScreenTransform;
    
    
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
        PauseScreenSetActive(false);
    }
    
    private void PauseScreenSetActive(bool active)
    {
        _pauseScreenTransform.gameObject.SetActive(active);
    }
}