using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int damage;

    private float deathTime;
    [SerializeField] private float deathTimer;

    private void Start()
    {
        deathTime = 0;
    }

    private void Update()
    {
        deathTime += Time.deltaTime;
        if (deathTime > deathTimer)
        {
            Destroy(gameObject);
        }
        Movement();

    }

    void Movement()
    {
        var dt = Time.deltaTime;
        transform.position = new Vector2(-transform.position.x + speed * transform.localScale.x * dt, transform.position.y);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<PlayerState>().currentHealth -= damage;

            Destroy(gameObject);
        }
    }
}

