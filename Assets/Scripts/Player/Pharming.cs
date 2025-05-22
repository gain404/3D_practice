using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Pharming : MonoBehaviour
{
    public Image Inventory;

    private void Start()
    {
        Inventory.gameObject.SetActive(false);
    }

    //tab 누르면 인벤토리가 열리는 메서드
    public void OnInventory(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            bool isOpen = Inventory.gameObject.activeSelf;
            Inventory.gameObject.SetActive(!isOpen);
        }
    }
}
