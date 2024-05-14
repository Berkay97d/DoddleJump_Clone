using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Scripts
{
    public class DoddleButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public event Action onDown;
        public event Action onUp;
        
        
        public void OnPointerDown(PointerEventData eventData)
        {
            onDown?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            onUp?.Invoke();
        }
    }
}