using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Pharming : MonoBehaviour
{
    public float checkRate = 0.05f;
    private float lastCheckTime;
    public float maxCheckDistance;
    public LayerMask layerMask;

    public GameObject curInteractGameObejct;
    public ItemObject itemObject;

    public Image Inventory;
    public TextMeshProUGUI promptText;
    
    private Camera camera;

    private void Awake()
    {
        camera = Camera.main;
    }

    private void Start()
    {
        Inventory.gameObject.SetActive(false);
    }

    
    //ray�� ���� ������Ʈ�� ������ ������ �ߴ� �޼���
    private void Update()
    {
        if (Time.time - lastCheckTime > checkRate)
        {
            lastCheckTime = Time.time;

            Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height / 2));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxCheckDistance, layerMask))
            {
                if (hit.collider.gameObject != curInteractGameObejct)
                {
                    curInteractGameObejct = hit.collider.gameObject;
                    itemObject = hit.collider.GetComponent<ItemObject>();
                    SetPromptText();
                }
            }
            else
            {
                curInteractGameObejct = null;
                itemObject = null;
                promptText.gameObject.SetActive(false);
            }
        }
    }

    private void SetPromptText()
    {
        promptText.gameObject.SetActive(true);
        promptText.text = itemObject.GetInteractPrompt();
    }

    //tab ������ �κ��丮�� ������ �޼���
    public void OnInventory(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            bool isOpen = Inventory.gameObject.activeSelf;
            Inventory.gameObject.SetActive(!isOpen);
        }
    }

    //eŰ�� ������ �������� �ݴ� �޼���
    public void PharmingItem(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && itemObject != null)
        {
            itemObject.OnInteract();
            curInteractGameObejct=null;
            itemObject = null;
            promptText.gameObject.SetActive(false);
        }
    }
}
