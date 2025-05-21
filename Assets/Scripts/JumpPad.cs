using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
   
   [SerializeField] private float jumpForce = 40f;

   void Start()
   {
      Debug.Log("JumpPad 스크립트 시작됨");
   }

   void Update()
   {
      // 매 프레임마다 플레이어와의 거리 체크
      GameObject player = GameObject.FindWithTag("Player");
      if (player != null)
      {
         float distance = Vector3.Distance(transform.position, player.transform.position);
         if (distance < 3f)
         {
            Debug.Log("플레이어가 근처에 있음: " + distance);
         }
      }
   }
   private void OnCollisionEnter(Collision collision)
   {
      if (collision.gameObject.CompareTag("Player"))
      {
         Debug.Log("점프대 작동!");
         Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
         if (playerRb != null)
         {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
         }
      }
   }


}
