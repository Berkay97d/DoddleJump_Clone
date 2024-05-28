using System;
using UnityEngine;

namespace Managers
{
    public class AudioManager : MonoBehaviour
    {
        private static AudioManager ms_Instance;


        private void Awake()
        {
            ms_Instance = this;
        }
    }
}