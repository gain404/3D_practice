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

    public void OnInteract() //������ �ֿ��� ��
    {
        CharacterManager.Instance.Player.itemData = itemData;
        CharacterManager.Instance.Player.addItem?.Invoke(); //addItem Action ȣ��
        Destroy(gameObject); //���� ������Ʈ �ı�
    }

}
