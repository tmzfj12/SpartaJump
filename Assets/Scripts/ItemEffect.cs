using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemEffect : MonoBehaviour
{
   private PlayerController playerController;
   private Condition playerCondition;
   
   private Coroutine speedBoostCoroutine;

   private void Start()
   {
      playerController = GetComponent<PlayerController>();
      playerCondition = GetComponent<Condition>();
      
   }

   public void ApplyEffect(ItemSO item)
   {
      if (item == null)
         return;

      switch (item.itemType)
      {
         case ItemSO.ItemType.Health :
            if (playerCondition != null)
            {
               playerCondition.Add(item.effectValue);
               Debug.Log($"체력이 {item.effectValue}회복되었습니다");
            }

            break;
         case ItemSO.ItemType.Speed:
            if (playerController != null)
            {
               if (speedBoostCoroutine != null)
               {
                  StopCoroutine(speedBoostCoroutine);
               }

               speedBoostCoroutine = StartCoroutine(SpeedBoostCoroutine(item));
            }

            break;
         
      }
   }

   private IEnumerator SpeedBoostCoroutine(ItemSO item)
   {
      float originalSpeed = playerController.moveSpeed;
      
      playerController.moveSpeed += item.effectValue;
      Debug.Log($"이동 속도가 {item.effectValue} 증가했습니다.(지속시간: {item.duration}초)");

      float curTime = item.duration;
      while (curTime > 0)
      {
         curTime -= Time.deltaTime;
         yield return null;
      }
      playerController.moveSpeed = originalSpeed;
      Debug.Log("속도 증가 효과가 종료되었습니다.");
      
      speedBoostCoroutine = null;

   }
   
   
    
}
