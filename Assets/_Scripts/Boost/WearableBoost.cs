using System;
using DG.Tweening;
using UnityEngine;

namespace _Scripts.Boost
{
    public class WearableBoost : MonoBehaviour
    {
        [SerializeField] private Animator _boostAnimator;
        [SerializeField] private float _boostLifeTime;
        [SerializeField] private float _boostMoveSpeed;

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
                    
                    StopBoostAnimation();
                    DropToDown();
                    
                    OnBoostOver?.Invoke();
                }
            }
        }

        private void StartBoostAnimation()
        {
            _boostAnimator.SetBool("isUsing", true);   
        }

        private void StopBoostAnimation()
        {
            _boostAnimator.SetBool("isUsing", false);
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
            
            StartBoostAnimation();
        }

        public float GetBoostMoveSpeed()
        {
            return _boostMoveSpeed;
        }
        
    }
}