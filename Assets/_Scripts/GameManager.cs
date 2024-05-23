using System;
using ScriptableObjects.CharacterVisuals;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action<CharacterVisualSO> OnCharacterVisualChanged;
    
    private static GameManager ms_Instance;
    
    private CharacterVisualSO m_CharacterVisual;


    private void Awake()
    {
        ms_Instance = this;
    }


    public static void SetCharacterVisual(CharacterVisualSO characterVisual)
    {
        ms_Instance.m_CharacterVisual = characterVisual;
        
        OnCharacterVisualChanged?.Invoke(characterVisual);
    }
    
    public static CharacterVisualSO GetCharacterVisual()
    {
        return ms_Instance.m_CharacterVisual;
    }
}