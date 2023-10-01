using System;
using UnityEngine;

namespace _Scripts
{
    public class PlatformDestroyer : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Platform"))
            {
                Destroy(col.gameObject);
            }
        }
    }
}