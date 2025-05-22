using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICondition : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private Image hungerBar;

    [SerializeField] private PlayerCondition playerCondition;

    private void Update()
    {
        UpdateHealthBar();
        UpdateHungerBar();
    }

    private void UpdateHealthBar()
    {
        healthBar.fillAmount = playerCondition.curHealth / playerCondition.maxHealth;
    }

    private void UpdateHungerBar()
    {
        hungerBar.fillAmount = playerCondition.curHunger / playerCondition.maxHunger;
    }
}
