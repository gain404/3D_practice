using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public delegate void InputItemSlot();
    public event InputItemSlot inputItmeSlot;
    private Image icon;

    //slot�� ���� �´� ������ ����ִ� �޼��� 
    private void InputIcon()
    {

    }
}
