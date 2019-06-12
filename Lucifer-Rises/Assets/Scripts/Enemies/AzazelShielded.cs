﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AzazelShielded : MonoBehaviour
{
    public Transform protectTarget, playerTransform;
    private GameObject protectOffsetPosition, playerFollowTransform;
    public GameObject unleashedForm, explosion;
    public bool shouldProtect = false;
    public int maxHP;
    public float speed, protectOffset, followOffset;
    private int hp;

    private void Start()
    {
        hp = maxHP;
        protectOffsetPosition = new GameObject();
        playerFollowTransform = new GameObject();
    }

    private void Update()
    {
        if (hp <= 0)
        {
            Explode();
        }

        if (shouldProtect && protectTarget != null)
        {
            protectOffsetPosition.transform.position = new Vector3(protectTarget.position.x, protectTarget.position.y - protectOffset, 0f);
            transform.position += Vector3.Normalize(protectOffsetPosition.transform.position - transform.position) * speed * Time.deltaTime;
        }
        else
        {
            playerFollowTransform.transform.position = new Vector3(playerTransform.position.x, followOffset, 0f);
            transform.position += Vector3.Normalize(playerFollowTransform.transform.position - transform.position) * speed * Time.deltaTime;
        }
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

    private void Explode()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        GameObject unleashedInstance = Instantiate(unleashedForm, transform.position, Quaternion.identity);
        unleashedInstance.GetComponent<AzazelUnleashed>().target = playerTransform;
        Destroy(this.gameObject);
    }
}