using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts.Platforms
{
    public class PlatformGroupInitilizor : MonoBehaviour
    {
        [SerializeField] private BackgroundSystem _backgroundSystem;
        [SerializeField] private Background _myBackground;
        [SerializeField] private PlatformGroup _startPlatformGroup;
        [SerializeField] private PlatformGroup[] _platformGroups;
        [SerializeField] private bool _isStartBackground;

        private PlatformGroup m_CurrentPlatformGroup;
        
        
        private void Start()
        {
            _backgroundSystem.OnBackgroundMoved += OnBackgroundMoved;

            if (_isStartBackground)
            {
                m_CurrentPlatformGroup = Instantiate(_startPlatformGroup);
                m_CurrentPlatformGroup.transform.SetParent(transform);
                m_CurrentPlatformGroup.transform.localPosition = Vector3.zero;
                
            }
            else
            {
                m_CurrentPlatformGroup = Instantiate(SelectRandomPlatformGroup());
                m_CurrentPlatformGroup.transform.SetParent(transform);
                m_CurrentPlatformGroup.transform.localPosition = Vector3.zero;
            }
        }

        private void OnDestroy()
        {
            _backgroundSystem.OnBackgroundMoved -= OnBackgroundMoved;
        }

        private void OnBackgroundMoved(Background obj)
        {
            if (obj != _myBackground)
            {
                return;
            }
            
            Destroy(m_CurrentPlatformGroup.gameObject);

            m_CurrentPlatformGroup = Instantiate(SelectRandomPlatformGroup(), transform);
            m_CurrentPlatformGroup.transform.localPosition = Vector3.zero;
        }

        private PlatformGroup SelectRandomPlatformGroup()
        {
            return _platformGroups[Random.Range(0, _platformGroups.Length)];
        }
    }
}