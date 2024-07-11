using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossHealth : MonoBehaviour
{
    public static BossHealth Instance { get; private set; }

    public int health;
    public int maxHealth = 30;

    public bool isInvulnerable = false;

    public UnityEvent changeHealth;

    private Animator anim;

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
        health = maxHealth;
        changeHealth = new UnityEvent();
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        if (isInvulnerable)
            return;

        health -= damage;
        changeHealth.Invoke();

        if (health <= 0)
        {
            StartCoroutine(DieCourotine());
        }
    }

    private IEnumerator DieCourotine()
    {
        anim.SetTrigger("Death");

        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);

        Destroy(this.gameObject);
    }
}
