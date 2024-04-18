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

    [SerializeField] private float speedEnemy = 3f;

    public void Start()
    {
        animator = GetComponent<Animator>();
        health = PlayerState.Instance;
    }

    public void Update()
    {
        CDTimer += Time.deltaTime;

        if (PlayerInSight())
        {
            if (CDTimer >= attackCD)
            {
                CDTimer = 0;

                StartCoroutine(AttackRoutine());    
            }
        }
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, playerMask);


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
            health.TakeDamage(damage);
        }
    }

    private IEnumerator AttackRoutine()
    {
        animator.SetTrigger("Attack");

        GetComponentInParent<EnemyPatrol>().speed = 0;

        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        GetComponentInParent<EnemyPatrol>().speed = speedEnemy;
    }
}
