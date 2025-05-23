using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public delegate void InputItemSlot();
    public event InputItemSlot inputItmeSlot;
    private Image icon;

    //slot에 각각 맞는 아이콘 집어넣는 메서드 
    private void InputIcon()
    {

    }
}
