using System;
using UnityEngine;

namespace _Scripts.Platforms
{
    public class PlatformGroupInitilizor : MonoBehaviour
    {
        [SerializeField] private BackgroundSystem _backgroundSystem;


        private void Start()
        {
            _backgroundSystem.OnBackgroundMoved += OnBackgroundMoved;
        }

        private void OnDestroy()
        {
            _backgroundSystem.OnBackgroundMoved -= OnBackgroundMoved;
        }

        private void OnBackgroundMoved(Background obj)
        {
            
        }
    }
}