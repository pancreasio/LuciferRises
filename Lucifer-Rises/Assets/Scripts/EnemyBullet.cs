using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject creator;
    public float speed, lifespan;
    private float lifeTime;
    public bool shouldDissapearIfParentKilled = false;

    private void Update()
    {
        lifeTime += Time.deltaTime;
        transform.position += -transform.up * speed * Time.deltaTime;
        if (lifeTime > lifespan)
        {
            Destroy(this.gameObject);
        }

        if (creator == null && shouldDissapearIfParentKilled)
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
