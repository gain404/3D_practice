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
    [Header("Item Info")]
    public ItemType Type;
    public Sprite ItemIcon;
    public GameObject Prefabs;

    public string Name;
    public string Description;
    
}
