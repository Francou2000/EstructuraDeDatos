using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
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
        transform.position = new Vector2(transform.position.x + speed * transform.localScale.x * dt, transform.position.y);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {       
        if (collision.transform.tag == "Enemy")
        {
            collision.transform.GetComponent<EnemyHealth>().currentHealth -= damage;
            collision.transform.GetComponent<EnemyHealth>().TakeDamage();

            Destroy(gameObject);
        }
    }
}
