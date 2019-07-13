using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public float speed, lifespan;
    private float lifeTime;
    void Update()
    {
        lifeTime += Time.deltaTime;
        transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
        if (lifeTime > lifespan)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
