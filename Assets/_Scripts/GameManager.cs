using System;
using ScriptableObjects.CharacterVisuals;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action<CharacterVisualSO> OnCharacterVisualChanged;
    
    private static GameManager ms_Instance;
    
    private CharacterVisualSO m_CharacterVisual;
    private bool m_CanPlay;


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
    
    
    public static void SetCanPlay(bool canPlay)
    {
        ms_Instance.m_CanPlay = canPlay;
    }
    
    public static bool GetCanPlay()
    {
        return ms_Instance.m_CanPlay;
    }
}