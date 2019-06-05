using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed, lifespan;
    private float lifeTime;
    void Update()
    {
        lifeTime += Time.deltaTime;
        transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
        if (lifeTime > lifespan)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag != "Bullet")
        {
            Destroy(this.gameObject);
        }
    }
}
