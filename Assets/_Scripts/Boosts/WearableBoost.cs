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
                    
                    _balloonActiveGameObject.SetActive(m_isActive);
                    _balloonInActiveGameObject.SetActive(!m_isActive);
                    
                    DropToDown();
                    
                    OnBoostOver?.Invoke();
                }
            }
        }

        private void DropToDown()
        {
            transform.parent = null;
            transform.DOMove(transform.position + Vector3.down * 20, 2).SetEase(Ease.InCirc).OnComplete(() =>
            {
                Destroy(gameObject);
            });
            Destroy(GetComponent<BoxCollider2D>());
        }
        
        public void TriggerBoost(Transform targetTransform)
        {
            transform.parent = targetTransform;
            transform.localPosition = Vector3.zero;

            m_isActive = true;
            
            _balloonActiveGameObject.SetActive(m_isActive);
            _balloonInActiveGameObject.SetActive(!m_isActive);
        }

        public float GetBoostMoveSpeed()
        {
            return _boostMoveSpeed;
        }
        
    }
}