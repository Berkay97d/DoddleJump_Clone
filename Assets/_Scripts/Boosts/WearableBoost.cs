using System;
using DG.Tweening;
using UnityEngine;

namespace Boosts
{
    public class WearableBoost : MonoBehaviour
    {
        [SerializeField] private float _boostLifeTime;
        [SerializeField] private float _boostMoveSpeed;
        [SerializeField] private GameObject _balloonActiveGameObject;
        [SerializeField] private GameObject _balloonInActiveGameObject;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public event Action OnBoostOver;
        
        private bool m_isActive;
        private float m_activePastTime;

        private void Update()
        {
            if (m_isActive)
            {
                m_activePastTime += Time.deltaTime;

                if (m_activePastTime > _boostLifeTime)
                {
                    m_isActive = false;

                    if (_balloonActiveGameObject != null) _balloonActiveGameObject.SetActive(m_isActive);
                    if (_balloonInActiveGameObject != null) _balloonInActiveGameObject.SetActive(!m_isActive);

                    DropToDown();
                    
                    OnBoostOver?.Invoke();
                }
            }
        }

        private void DropToDown()
        {
            transform.parent = null;
            
            GetComponent<BoxCollider2D>().enabled = false;
            /*
            transform.DOScale(Vector3.one * 0.01f, 0.25f).SetEase(Ease.InCirc).OnComplete(() =>
            {
                gameObject.SetActive(false);
            });
            */
            
            gameObject.SetActive(false);
        }
        
        public void TriggerBoost(Transform targetTransform)
        {
            transform.parent = targetTransform;
            transform.localPosition = Vector3.zero;

            m_isActive = true;

            if (_balloonActiveGameObject != null) _balloonActiveGameObject.SetActive(m_isActive);
            if (_balloonInActiveGameObject != null) _balloonInActiveGameObject.SetActive(!m_isActive);
        }

        public float GetBoostMoveSpeed()
        {
            return _boostMoveSpeed;
        }
        
    }
}