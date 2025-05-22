using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
   public ItemSO itemData;


   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Player"))
      {
         Debug.Log($"{itemData.itemName} 아이템을 획득했습니다.");

         ItemEffect itemEffect = other.GetComponent<ItemEffect>();
         if (itemEffect != null)
         {
            itemEffect.ApplyEffect(itemData);
            Destroy(gameObject);

         }


      }
   }
}
