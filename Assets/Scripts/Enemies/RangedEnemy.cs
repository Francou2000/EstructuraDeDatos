using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public float attackCD;
    private float CDTimer = Mathf.Infinity;
    public float range;

    public BoxCollider2D boxCollider;
    public float colliderDistance;

    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bullets;

    public LayerMask playerMask;

    private Animator animator;

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

    private void Shoot()
    {
        CDTimer = 0;

        Instantiate(bullets, firePoint.position, Quaternion.identity);
    }

    private IEnumerator AttackRoutine()
    {
        animator.SetTrigger("Shoot");

        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
    }
}
