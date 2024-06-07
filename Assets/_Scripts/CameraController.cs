using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class CameraController : MonoBehaviour
    {
        public SpriteRenderer rink;

        private Camera m_MainCamera;
        
        
        private void Awake()
        {
            m_MainCamera = Camera.main;
        }

        private void Update()
        {
            float screenAspect = (float)Screen.width / (float)Screen.height;
            float targetAspect = rink.bounds.size.x / rink.bounds.size.y;

            if (screenAspect >= targetAspect)
            {
                m_MainCamera.orthographicSize = rink.bounds.size.y / 2;
            }
            else
            {
                m_MainCamera.orthographicSize = (rink.bounds.size.x / 2) / screenAspect;
            }
        }
    }
}