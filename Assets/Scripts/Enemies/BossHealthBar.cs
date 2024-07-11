using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public Slider slider;

    BossHealth boss;

    private float currentHealth;
    private float maxHealth;

    void Start()
    {
        slider = GetComponent<Slider>();
        boss = BossHealth.Instance;
        boss.changeHealth.AddListener(ChangeHealth);
    }

    void ChangeHealth()
    {
        currentHealth = boss.health;
        maxHealth = boss.maxHealth;

        Debug.Log(currentHealth.ToString());

        float fillValue = currentHealth / maxHealth;
        slider.value = fillValue;
    }
}
