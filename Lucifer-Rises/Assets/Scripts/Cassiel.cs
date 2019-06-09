using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cassiel : MonoBehaviour
{
    public int maxHp;
    private int hp;
    public float fireRate;
    private float fireClock;
    public GameObject bullet;
    public Transform cannon;

    private void Start()
    {
        hp = maxHp;
        fireClock = 0;
    }

    private void Update()
    {
        fireClock += Time.deltaTime;

        if (hp <= 0)
        {
            Explode();
        }

        if (fireClock > fireRate)
        {
            Fire();
            fireClock = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Bullet")
        {
            hp--;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {        
        Explode();
    }

    private void Fire()
    {
        Instantiate(bullet, cannon.position, Quaternion.identity);
    }

    private void Explode()
    {
        Destroy(this.gameObject);
    }
}
