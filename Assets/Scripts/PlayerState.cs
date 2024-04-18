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

    public bool isInvencible;

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
        isInvencible = false;
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
        if (isInvencible)
        {
            damage = 0;
        }
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
