using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AzazelUnleashed : MonoBehaviour
{
    public float speed;
    public int maxHP;
    private int hp;
    public Transform target;

    void Start()
    {
        hp = maxHP;
    }

    void Update()
    {
        if (hp <= 0)
        {
            Explode();
        }

        transform.right = target.position - transform.position;
        transform.position += transform.right * speed * Time.deltaTime;
    }

    private void Explode()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Explode();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            hp--;
        }
    }
}
