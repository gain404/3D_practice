using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ConditionType
{
    Health,
    Hunger
}

public class PlayerCondition : MonoBehaviour
{
    [Header("Value Control")]
    public float curHealth;
    public float maxHealth = 10;
    public float curHunger;
    public float maxHunger = 10;

    public float subtractHealth = 1;
    public float subtractHunger = 1;

    private void Start()
    {
        curHealth = maxHealth;
        curHunger = maxHunger;
    }

    private void Update()
    {
        SubtractHunger();
    }

    //시간에 따라 배고픔이 줄어드는 메서드
    private void SubtractHunger()
    {
        curHunger -= subtractHunger * Time.deltaTime;
        if (curHunger <= 0)
        {
            curHealth -= subtractHealth * Time.deltaTime;
        }
    }

    //적에게 맞으면 체력이 줄어드는 메서드
}
