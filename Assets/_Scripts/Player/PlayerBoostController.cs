using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoostController : MonoBehaviour
{
   [SerializeField] private Transform _capBoostParent;
   [SerializeField] private Transform _backpackBoostParent;

   private bool m_İsBoosted;
   
   
   private void OnCollisionEnter2D(Collision2D col)
   {
      if (m_İsBoosted) return;

      if (col.collider.CompareTag("Cap"))
      {
            
      }
        
      if (col.collider.CompareTag("Backpack"))
      {
         
      }
      
   }
   
}
