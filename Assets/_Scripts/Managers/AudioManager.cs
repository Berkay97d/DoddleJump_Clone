using System;
using UnityEngine;

namespace Managers
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _buttonClickAudioSource;
        [SerializeField] private AudioSource _winPopUpAudioSource;
        
        private static AudioManager ms_Instance;


        private void Awake()
        {
            ms_Instance = this;
        }
        
        
        public static void PlayButtonClickSound()
        {
            ms_Instance._buttonClickAudioSource.Play();
        }
        
        public static void PlayWinPopUpSound()
        {
            ms_Instance._winPopUpAudioSource.Play();
        }
    }
}