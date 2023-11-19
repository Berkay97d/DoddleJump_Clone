using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.Boost;
using UnityEngine;

public class PlayerBoostController : MonoBehaviour
{
   [SerializeField] private Transform _capBoostParent;
   [SerializeField] private Transform _backpackBoostParent;

   private bool m_İsBoosted;
   private WearableBoost m_WearableBoost;
   private Rigidbody2D m_Rb;


   private void Awake()
   {
       m_Rb = GetComponent<Rigidbody2D>();
   }

   private void Update()
   {
       if (m_İsBoosted)
       {
            m_Rb.velocity = Vector2.zero;
            transform.position += Vector3.up * m_WearableBoost.GetBoostMoveSpeed() * Time.deltaTime;
       }
   }


   private void OnTriggerEnter2D(Collider2D col)
   {
       if (m_İsBoosted) return;

       if (col.CompareTag("Cap") && col.gameObject.TryGetComponent(out WearableBoost wearableBoostCap))
       {
           wearableBoostCap.TriggerBoost(_capBoostParent);

           m_WearableBoost = wearableBoostCap;
            
           wearableBoostCap.OnBoostOver += OnBoostOver;

           m_İsBoosted = true;
       }

       if (col.CompareTag("Rocket") && col.gameObject.TryGetComponent(out WearableBoost wearableBoostRocket))
       {
           wearableBoostRocket.TriggerBoost(_backpackBoostParent);
          
           m_WearableBoost = wearableBoostRocket;
          
           wearableBoostRocket.OnBoostOver += OnBoostOver;
          
           m_İsBoosted = true;
       }
   }
   

   private void OnBoostOver()
   {
       m_İsBoosted = false;
       m_WearableBoost.OnBoostOver -= OnBoostOver;
       
       m_Rb.velocity = Vector2.up * 7;
   }
}
