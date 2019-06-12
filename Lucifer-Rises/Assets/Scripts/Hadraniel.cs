using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hadraniel : MonoBehaviour
{
    public int maxHp;
    private int hp, cannonSwitch;
    private bool shouldFire;
    public float fireRate, speed, waypointOffset;
    private float fireClock;
    public GameObject bullet, explosion;
    public Transform cannon0, cannon1, cannon2, endPoint;

    private void Start()
    {
        hp = maxHp;
        fireClock = 0;
        cannonSwitch = 0;
        shouldFire = false;
    }

    void Update()
    {
        if (Vector3.Distance(endPoint.position, transform.position) < waypointOffset)
        {
            shouldFire = true;
        }
        else
        {
            transform.position += Vector3.Normalize(endPoint.position - transform.position) * speed * Time.deltaTime;
        }

        if (shouldFire)
        {
            fireClock += Time.deltaTime;
            if (fireClock > fireRate)
            {
                switch (cannonSwitch)
                {
                    case 0:
                        Fire(cannon0);
                        fireClock = 0;
                        cannonSwitch = 1;
                        break;
                    case 1:
                        Fire(cannon1);
                        fireClock = 0;
                        cannonSwitch = 2;
                        break;
                    case 2:
                        Fire(cannon2);
                        fireClock = 0;
                        cannonSwitch = 0;
                        break;
                    default:
                        break;
                }
            }
        }

        if (hp <= 0)
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag != "Player")
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }

    private void Fire(Transform cannon)
    {
        GameObject bulletInstance = Instantiate(bullet, cannon.position, Quaternion.identity);
        bulletInstance.GetComponent<EnemyBullet>().creator = this.gameObject;
        bulletInstance.GetComponent<EnemyBullet>().shouldDissapearIfParentKilled = true;
    }

    private void Explode()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}