using System;
using UnityEngine;

namespace Players
{
    public class PlayerDeadChecker : MonoBehaviour
    {
        private float m_DeadGap;
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
                OnPlayerDead?.Invoke();
                m_IsDead = true;
            }
        }

        private bool CheckIsDead()
        {
            if (PlayerProperties.HighestWidth - transform.position.y > 5.5)
            {
                return true;
            }

            return false;
        }
    }
}
