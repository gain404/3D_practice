using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    weapon,
    food,
    meterial
}


[CreateAssetMenu]
public class ItemData : ScriptableObject
{
    [Header("Item properties")]
    public ItemType Type;
    public Sprite ItemIcon;

    public string Name;
    public string Description;
    
}
