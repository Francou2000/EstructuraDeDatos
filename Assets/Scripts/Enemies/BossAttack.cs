using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public int meleeAttackDamage = 20;
    public int rangeAttackDamage = 40;

    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;

    public GameObject bullet;
    public GameObject rangeAttackPosition;
    public GameObject bulletSpawnPoint;

    public void MeleeAttack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<PlayerState>().TakeDamage(meleeAttackDamage);
        }
    }

    public void SpawnRangeAttack()
    {
        Instantiate(bullet, bulletSpawnPoint.transform.position , Quaternion.identity);
    }

    public void Reposition()
    {
        transform.position = rangeAttackPosition.transform.position;
    }

    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }
}
