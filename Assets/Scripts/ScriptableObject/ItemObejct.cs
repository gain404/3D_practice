using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObejct : MonoBehaviour
{
    public ItemData itemData;

    public string GetInteractPrompt()
    {
        string str = $"{itemData.Name}\n{itemData.Description}";
        return str;
    }

    public void OnInteract() //아이템 주웠을 때
    {
        CharacterManager.Instance.Player.itemData = itemData;
        CharacterManager.Instance.Player.addItem?.Invoke(); //addItem Action 호출
        Destroy(gameObject); //게임 오브젝트 파괴
    }

}
