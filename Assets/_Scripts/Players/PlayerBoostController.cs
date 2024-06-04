using Boosts;
using UnityEngine;

namespace Players
{
    public class PlayerBoostController : MonoBehaviour
    {
        [SerializeField] private Transform _capBoostParent;
        [SerializeField] private Transform _backpackBoostParent;
        [SerializeField] private Player _player;

        private bool m_IsBoosted;
        private WearableBoost m_WearableBoost;
        private Rigidbody2D m_Rb;


        private void Awake()
        {
            m_Rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (m_IsBoosted)
            {
                m_Rb.velocity = Vector2.zero;
                transform.position += Vector3.up * m_WearableBoost.GetBoostMoveSpeed() * Time.deltaTime;
            }
        }


        private void OnTriggerEnter2D(Collider2D col)
        {
            if (m_IsBoosted) return;

            if (col.CompareTag("Cap") && col.gameObject.TryGetComponent(out WearableBoost wearableBoostCap))
            {
                wearableBoostCap.TriggerBoost(_capBoostParent);

                m_WearableBoost = wearableBoostCap;
            
                wearableBoostCap.OnBoostOver += OnBoostOver;

                m_IsBoosted = true;
                _player.SetHasBoost(true);
                _player.SetCanDead(false);
            }

            if (col.CompareTag("Rocket") && col.gameObject.TryGetComponent(out WearableBoost wearableBoostRocket))
            {
                wearableBoostRocket.TriggerBoost(_backpackBoostParent);
          
                m_WearableBoost = wearableBoostRocket;
          
                wearableBoostRocket.OnBoostOver += OnBoostOver;
          
                m_IsBoosted = true;
                _player.SetHasBoost(true);
                _player.SetCanDead(false);
            }
        }
   

        private void OnBoostOver()
        {
            m_IsBoosted = false;
            m_WearableBoost.OnBoostOver -= OnBoostOver;
       
            m_Rb.velocity = Vector2.up * 7;
        }
        
        
        public bool GetIsBoosted()
        {
            return m_IsBoosted;
        }
    }
}
