using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Managers
{
    public class TouchInputManager : MonoBehaviour
    {
        public static event Action<Vector2> OnWorldPositionChanged;
        public static event Action OnTouchEnded;

        private static TouchInputManager ms_Instance;

        private Camera m_MainCamera;

        private void Awake()
        {
            ms_Instance = this;
            m_MainCamera = Camera.main;
        }

        private void Update()
        {
            TryUpdatePosition();
        }

        private bool TryUpdatePosition()
        {
            if (IsPointerOverUIObject()) return false;

            UpdatePosition();
            return true;
        }

        private static void UpdatePosition()
        {
            Vector2 touchPosition = GetTouchPosition();
        
            Vector2 worldPosition = GetWorldPosition();
            OnWorldPositionChanged?.Invoke(worldPosition);
        
            Vector2 touchEndPosition = GetTouchEndPosition();

            if (touchEndPosition != Vector2.zero)
            {
                OnTouchEnded?.Invoke();
            }
        }


        private bool IsPointerOverUIObject() {
            PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
            eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
            return results.Count > 0;
        }
        

        private static Vector2 GetTouchPosition()
        {
            if (Input.touchCount <= 0) return Vector2.zero;
        
            Touch touch = Input.GetTouch(0);

            if (touch.phase is TouchPhase.Began or TouchPhase.Moved or TouchPhase.Stationary)
            {
                return touch.position;
            }

            return Vector2.zero;
        }

        private static Vector2 GetTouchEndPosition()
        {
            if (Input.touchCount <= 0) return Vector2.zero;
        
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Ended)
            {
                return touch.position;
            }

            return Vector2.zero;
        }

    
        public static Vector2 GetWorldPosition()
        {
            Vector2 touchPosition = GetTouchPosition();
            if (touchPosition != Vector2.zero)
            {
                return ms_Instance.m_MainCamera.ScreenToWorldPoint(new Vector2(touchPosition.x, touchPosition.y));
            }

            return Vector2.zero;
        }
    }
}