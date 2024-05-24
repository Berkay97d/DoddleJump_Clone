using UnityEngine;

namespace Players
{
    public class PlayerTeleport : MonoBehaviour
    {
        private float m_XLim;
        private float m_TpPos;

        private void Start()
        {
            SetXLimAndTpPos();
        }

        private void Update()
        {
            Teleport();
        }

        private void SetXLimAndTpPos()
        {
            float aspectRatio = Camera.main.aspect; // Ekranın en-boy oranı
            float verticalSize = Camera.main.orthographicSize; // Ekranın dikey boyutu
            m_XLim = aspectRatio * verticalSize; // Ekranın yatay boyutu
            m_TpPos = m_XLim; // Işınlanma pozisyonunu ekranın diğer yanı olarak ayarla
        }

        private void Teleport()
        {
            if (transform.position.x > m_XLim)
            {
                var position = transform.position;
                position.x = -m_TpPos;
                transform.position = position;
            }
            else if (transform.position.x < -m_XLim)
            {
                var position = transform.position;
                position.x = m_TpPos;
                transform.position = position;
            }
        }
    }
}