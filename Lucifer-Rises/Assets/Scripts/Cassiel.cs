using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cassiel : MonoBehaviour
{
    public int maxHp;
    private int hp;

    private void Start()
    {
        hp = maxHp;
    }

    private void Update()
    {
        if (hp <= 0)
        {
            Explode();
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

    private void Explode()
    {
        Destroy(this.gameObject);
    }
}
