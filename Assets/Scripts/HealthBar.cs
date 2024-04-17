using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public GameObject player;

    private float currentHealth;
    private float maxHealth;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        currentHealth = player.GetComponent<PlayerState>().currentHealth;
        maxHealth = player.GetComponent<PlayerState>().maxHealth;

        float fillValue = currentHealth / maxHealth;
        slider.value = fillValue;
    }
}
