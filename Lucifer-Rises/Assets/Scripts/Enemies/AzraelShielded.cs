using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AzraelShielded : MonoBehaviour
{
    public Transform protectTarget, playerTransform;
    private GameObject protectDeltaTarget, playerFollowTarget;
    public GameObject unleashedForm, explosion;
    public bool shouldProtect = false;
    public int maxHP;
    public float speed, protectOffset, followOffset, dontJitter;
    private int hp;

    private void Start()
    {
        hp = maxHP;
        if (!playerTransform)
        {
            playerTransform = GameObject.Find("Lucifer").transform;
        }
        if (!protectTarget)
        {
            FindProtectTarget();
        }
        protectDeltaTarget = new GameObject();
        playerFollowTarget = new GameObject();
    }



    private void Update()
    {
        if (hp <= 0)
        {
            Explode();
        }

        if (shouldProtect && protectTarget != null)
        {

            protectDeltaTarget.transform.position = new Vector3(protectTarget.position.x, protectTarget.position.y - protectOffset, 0f);
            if (Vector3.Distance(this.transform.position, protectDeltaTarget.transform.position) > dontJitter)
            {
                transform.position += Vector3.Normalize(protectDeltaTarget.transform.position - transform.position) * speed * Time.deltaTime;
            }
        }
        else
        {

            playerFollowTarget.transform.position = new Vector3(playerTransform.position.x, followOffset, 0f);
            if (Vector3.Distance(this.transform.position, playerFollowTarget.transform.position) > dontJitter)
            {
                transform.position += Vector3.Normalize(playerFollowTarget.transform.position - transform.position) * speed * Time.deltaTime;
            }
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
        unleashedInstance.GetComponent<AzraelUnleashed>().target = playerTransform;
        Destroy(this.gameObject);
    }

    private void FindProtectTarget()
    {
        GameObject newTarget = new GameObject();
        if ((newTarget = GameObject.Find("Abaddon")) && newTarget)
        {
            protectTarget = newTarget.transform;
        }
        else
        {
            if ((newTarget = GameObject.Find("Hadraniel")) && newTarget)
            {
                protectTarget = newTarget.transform;
            }
            else
            {
                protectTarget = null;
            }
        }
    }
}
