using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    
    private Vector2 moveInput;
    private Vector2 lookInput;
   

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float lookSensitivity = 2f;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private LayerMask groundLayerMask;

    
    

   private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
        }
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnLookInput(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveInput.x, 0, moveInput.y);

        if (cameraTransform != null)
        {
            movement = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0) * movement;
        }

        rb.AddForce(movement.normalized * moveSpeed, ForceMode.Force);
    }
    //카메라 회전
    private float rotationX = 0f;

    private void Update()
    {
        Debug.Log(IsGrounded());
        if (lookInput != Vector2.zero && cameraTransform != null)
        {
            //좌우 회전 - 캐릭터 스프라이트가 생기면..
            transform.Rotate(Vector3.up, lookInput.x * lookSensitivity);
            
            //상하 회전 - 카메라만
            rotationX -= lookInput.y*lookSensitivity;
            rotationX = Mathf.Clamp(rotationX, -90f, 90f);
            cameraTransform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        }
    }

    bool IsGrounded()
    {
        // 플레이어 위치에서 약간 아래쪽에 구체 충돌 검사
        Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - 0.9f, transform.position.z);
    
        // 실제 충돌 검사 수행 (0.3f는 구체의 반지름)
        return Physics.CheckSphere(spherePosition, 0.3f, groundLayerMask);
    }

// 에디터에서만 시각화를 위한 함수 
    private void OnDrawGizmos()
    {
        // IsGrounded 시각화용 구체 표시
        Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - 0.9f, transform.position.z);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(spherePosition, 0.3f);
    }

    // Update is called once per frame
    
}
