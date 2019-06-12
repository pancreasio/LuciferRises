using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abaddon : MonoBehaviour
{
    public int maxHp;
    private int hp;
    public Transform cannon0, cannon1, cannon2, cannon3, cannon4, cannon5, endPoint;
    public GameObject bullet, explosion;
    public float fireRate, speed, waypointOffset, rotationSpeed;
    private float fireClock;

    private void Start()
    {
        hp = maxHp;
        fireClock = 0;
    }

    void Update()
    {
        if (Vector3.Distance(endPoint.position, transform.position) > waypointOffset)
        {
            transform.position += Vector3.Normalize(endPoint.position - transform.position) * speed * Time.deltaTime;
        }
        fireClock += Time.deltaTime;
        if (fireClock >= fireRate)
        {
            fireClock = 0;
            Fire();
        }
        transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);

        if (hp <= 0)
        {
            Explode();
        }
    }

    private void Explode()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
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

    private void Fire()
    {
        GameObject bulletInstance = Instantiate(bullet, cannon0.position, cannon0.rotation);
        bulletInstance.GetComponent<EnemyBullet>().creator = this.gameObject;
        bulletInstance.GetComponent<EnemyBullet>().shouldDissapearIfParentKilled = true;

        bulletInstance = Instantiate(bullet, cannon1.position, cannon1.rotation);
        bulletInstance.GetComponent<EnemyBullet>().creator = this.gameObject;
        bulletInstance.GetComponent<EnemyBullet>().shouldDissapearIfParentKilled = true;

        bulletInstance = Instantiate(bullet, cannon2.position, cannon2.rotation);
        bulletInstance.GetComponent<EnemyBullet>().creator = this.gameObject;
        bulletInstance.GetComponent<EnemyBullet>().shouldDissapearIfParentKilled = true;

        bulletInstance = Instantiate(bullet, cannon3.position, cannon3.rotation);
        bulletInstance.GetComponent<EnemyBullet>().creator = this.gameObject;
        bulletInstance.GetComponent<EnemyBullet>().shouldDissapearIfParentKilled = true;

        bulletInstance = Instantiate(bullet, cannon4.position, cannon4.rotation);
        bulletInstance.GetComponent<EnemyBullet>().creator = this.gameObject;
        bulletInstance.GetComponent<EnemyBullet>().shouldDissapearIfParentKilled = true;

        bulletInstance = Instantiate(bullet, cannon5.position, cannon5.rotation);
        bulletInstance.GetComponent<EnemyBullet>().creator = this.gameObject;
        bulletInstance.GetComponent<EnemyBullet>().shouldDissapearIfParentKilled = true;

    }
}
