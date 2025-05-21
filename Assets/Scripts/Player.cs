using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
   public void OnMove(InputAction.CallbackContext context)
   {
      var value = context.ReadValue<Vector2>();
   }
}
