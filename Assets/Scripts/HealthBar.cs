using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    PlayerState player;

    private float currentHealth;
    private float maxHealth;

    void Start()
    {
        slider = GetComponent<Slider>();
        player = PlayerState.Instance;
        player.changeHealth.AddListener(ChangeHealth);
    }

    void ChangeHealth()
    {
        currentHealth = player.currentHealth;
        maxHealth = player.maxHealth;

        Debug.Log(currentHealth.ToString());

        float fillValue = currentHealth / maxHealth;
        slider.value = fillValue;
    }
}
