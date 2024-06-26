using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 10f;

    private Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();

        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
           Death();

        }
    }

    private void Death()
    {
        StartCoroutine(DeathRoutine());
    }

    public void TakeDamage()
    {
        StartCoroutine(TakeHitRoutine());
    }

    private IEnumerator DeathRoutine()
    {
        animator.SetTrigger("Death");

        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        EnemyCounter.Instance.enemiesOnLevelLeft--;

        Destroy(gameObject);
    }

    private IEnumerator TakeHitRoutine()
    {
        animator.SetTrigger("TakeHit");

        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
    }
}
