using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //5. �κ��丮 ����
    //tab�� ������ �κ��丮�� ������ �޼���

    //6. ������

    [Header("Movement")]
    public float moveSpeed;
    public float runSpeed;
    public float jumpScale;
    public LayerMask groundLayerMask;
    private Vector2 curMovementInput;
    private bool isRunning;

    [Header("Look")]
    public Transform cameraContainer; //cameraContainer��� ��ġ ����
    public float minXLook; //�� �� �ִ� X��ǥ�� ������ ��
    public float maxXLook;
    public float lookSensitivity; //�ΰ���
    private float camCurXRot; //���� ī�޶� ����(x�� -�� ������ �Ʒ���, +�� �Ʒ����� ����)

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

    //�����̴� �̺�Ʈ �޼���
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

    //�޸��� �̺�Ʈ �޼���
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

    //�����ϴ� �̺�Ʈ �޼���
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && IsGround())
        {
            rb.AddForce(Vector2.up * jumpScale, ForceMode.Impulse);
        }
    }

    //�����̴� �� ��������
    private void Move()
    {
        float speed = isRunning ? runSpeed : moveSpeed;

        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= speed;
        dir.y = rb.velocity.y;
        rb.velocity = dir;
    }

    //���� �̵� input �޴� �޼���
    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    //���� ���� �̵� �޼���
    private void CameraLook()
    {
        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);

        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
    }

    //�ٴڰ���
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
