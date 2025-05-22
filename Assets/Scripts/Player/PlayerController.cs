using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //5. 인벤토리 열기
    //tab을 누르면 인벤토리가 열리는 메서드

    //6. 때리기

    [Header("Movement")]
    public float moveSpeed;
    public float runSpeed;
    public float jumpScale;
    public LayerMask groundLayerMask;
    private Vector2 curMovementInput;
    private bool isRunning;

    [Header("Look")]
    public Transform cameraContainer; //cameraContainer라는 위치 정보
    public float minXLook; //볼 수 있는 X좌표에 제한을 둠
    public float maxXLook;
    public float lookSensitivity; //민감도
    private float camCurXRot; //현재 카메라 각도(x가 -면 위에서 아래로, +면 아래에서 위로)

    private Rigidbody rb;
    private Vector2 mouseDelta;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        LockCursor();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        CameraLook();
    }

    //움직이는 이벤트 메서드
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
        }
    }

    //달리는 이벤트 메서드
    public void OnRunInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            isRunning = true;
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            isRunning = false;
        }
    }

    //점프하는 이벤트 메서드
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && IsGround())
        {
            rb.AddForce(Vector2.up * jumpScale, ForceMode.Impulse);
        }
    }

    //움직이는 값 설정해줌
    private void Move()
    {
        float speed = isRunning ? runSpeed : moveSpeed;

        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= speed;
        dir.y = rb.velocity.y;
        rb.velocity = dir;
    }

    //시점 이동 input 받는 메서드
    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    //실제 시점 이동 메서드
    private void CameraLook()
    {
        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);

        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
    }

    //바닥감지
    private bool IsGround()
    {
        Ray ray = new Ray (transform.position, Vector3.down);

        if (Physics.Raycast(ray, 2f, groundLayerMask))
            return true;

        return false;
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}
