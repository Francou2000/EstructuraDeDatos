using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    public float attackCD;
    private float CDTimer = Mathf.Infinity;
    public float range;
    public BoxCollider2D boxCollider;
    public float colliderDistance;
    
    public int damage;

    public LayerMask playerMask;

    private Animator animator;
    private PlayerState health;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        CDTimer += Time.deltaTime;

        if (PlayerInSight())
        {
            if (CDTimer >= attackCD)
            {
                CDTimer = 0;

                animator.SetTrigger("Attack");
            }
        }
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, playerMask);

        if(hit.collider != null)
        {
            health = hit.transform.GetComponent<PlayerState>();
        }

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        if (PlayerInSight())
        {
            health.currentHealth -= damage;
        }
    }
}
