using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 100f;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();

        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            StartCoroutine(DeathRoutine()); 
        }
    }

    private IEnumerator DeathRoutine()
    {
        animator.SetTrigger("Death");

        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        Destroy(this.gameObject);
    }
}
