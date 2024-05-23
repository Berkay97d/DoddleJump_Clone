using System;
using ScriptableObjects.CharacterVisuals;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CharacterIconButton : MonoBehaviour
{ 
    [SerializeField] private Transform _characterVisualsParent;
    [SerializeField] private CharacterVisualSO _characterVisual;
    [SerializeField] private Button _button;


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
        
        CharacterVisualsParentSetActive(false);
        GameManager.SetCharacterVisual(_characterVisual);
        GameManager.SetCanPlay(true);
    }

    
    private void CharacterVisualsParentSetActive(bool active)
    {
        _characterVisualsParent.gameObject.SetActive(active);
    }
}