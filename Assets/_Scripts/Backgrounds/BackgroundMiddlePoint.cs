using System;
using UnityEngine;

namespace Backgrounds
{
    public class BackgroundMiddlePoint : MonoBehaviour
    {
        public event Action OnPlayerReached;
        
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                Debug.Log("Player reached middle");
                OnPlayerReached?.Invoke();
            }
        }
    }
}