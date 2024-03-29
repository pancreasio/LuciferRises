﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AzraelUnleashed : MonoBehaviour
{
    public float speed;
    public int maxHP;
    private int hp;
    public Transform target;
    public GameObject explosion;

    void Start()
    {
        hp = maxHP;
        if (!target)
        {
            GameObject targetObject = GameObject.Find("Lucifer");
            if (targetObject)
            {
                target = targetObject.transform;
            }
        }
    }

    void Update()
    {
        if (hp <= 0)
        {
            Explode();
        }

        if (!target)
        {
            Explode();
        }
        else
        {
            transform.right = -(target.position - transform.position);
            transform.position -= transform.right * speed * Time.deltaTime;
        }
    }

    private void Explode()
    {
        Wave.EnemyDied();
        GameManager.score += 50;
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Explode();
        }
        else
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
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
