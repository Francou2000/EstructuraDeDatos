using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerState : MonoBehaviour
{
    public static PlayerState Instance { get; private set; }

    public float currentHealth;
    public float maxHealth = 100;

    public UnityEvent changeHealth;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        currentHealth = maxHealth;
        changeHealth = new UnityEvent();
    }

    public void IsDead()
    {
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        changeHealth.Invoke();
        IsDead();

    }

    public void HealDamage(int healedDamage)
    {
        currentHealth += healedDamage;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        changeHealth.Invoke();
    }
}
