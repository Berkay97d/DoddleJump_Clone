using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Players
{
    public class PlayerDeadChecker : MonoBehaviour
    {
        private bool m_IsDead = false;

        public static PlayerDeadChecker Instance;
        public event Action OnPlayerDead;

        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            if (CheckIsDead() && !m_IsDead)
            {
                OnPlayerDeadInvoke();
            }
        }

        private bool CheckIsDead()
        {
            float screenBottomY = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
            if (transform.position.y < screenBottomY)
            {
                return true;
            }
            return false;
        }

        public void OnPlayerDeadInvoke()
        {
            OnPlayerDead?.Invoke();
            m_IsDead = true;
            gameObject.SetActive(false);
            
            KuponCall();
        }

        private async void KuponCall()
        {
            await UniTask.WaitForSeconds(0.5f);
            GameManager.QuitGame();
        }
    }
}