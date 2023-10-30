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
        [SerializeField] private Transform platformGroupParent;
        
        
        private PlatformGroup m_CurrentPlatformGroup;
        
        
        private void Start()
        {
            _backgroundSystem.OnBackgroundMoved += OnBackgroundMoved;

            if (_isStartBackground)
            {
                m_CurrentPlatformGroup = Instantiate(_startPlatformGroup, platformGroupParent);
                m_CurrentPlatformGroup.transform.position = transform.position;
                
            }
            else
            {
                m_CurrentPlatformGroup = Instantiate(SelectRandomPlatformGroup(), platformGroupParent);
                m_CurrentPlatformGroup.transform.position = transform.position;
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

            m_CurrentPlatformGroup = Instantiate(SelectRandomPlatformGroup(), platformGroupParent);
            m_CurrentPlatformGroup.transform.position = transform.position;
        }

        private PlatformGroup SelectRandomPlatformGroup()
        {
            return _platformGroups[Random.Range(0, _platformGroups.Length)];
        }
        
        //TODO: SCORE - HIGSCORE - CAP - ROCKET - RESTART GAME - PLATFORM GROUP VARIATIONS - FIRE - 2 MONSTER
    }
}