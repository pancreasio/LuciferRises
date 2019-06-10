using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cassiel : MonoBehaviour
{
    public int maxHp;
    private int hp, waypointPosition;
    public float fireRate, speed, waypointOffset;
    private float fireClock;
    public GameObject bullet;
    public Transform cannon;
    public List<Transform> waypoints;
    public Transform endPoint;


    private void Start()
    {
        hp = maxHp;
        fireClock = 0;
        waypointPosition = 0;
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

        if (waypointPosition >= waypoints.Count)
        {
            transform.position += Vector3.Normalize(endPoint.position - transform.position) * speed * Time.deltaTime;
            if (Vector3.Distance(endPoint.position, transform.position) < waypointOffset)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            transform.position += Vector3.Normalize(waypoints[waypointPosition].position - transform.position) * speed * Time.deltaTime;
            if (Vector3.Distance(waypoints[waypointPosition].transform.position, transform.position) < waypointOffset)
            {
                waypointPosition++;
            }
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
        GameObject bulletInstance = Instantiate(bullet, cannon.position, Quaternion.identity);
    }

    private void Explode()
    {
        Destroy(this.gameObject);
    }
}