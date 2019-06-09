using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lucifer : MonoBehaviour
{
    public float speedX, speedY, fireRate, maxHP;
    private float inputX, inputY, fireClock, hp;
    public GameObject bullet;
    private Transform bounds, cannon1, cannon2, cannon3, cannon4;

    private void Start()
    {
        bounds = GameObject.Find("Bounds").transform;
        cannon1 = GameObject.Find("Cannon1").transform;
        cannon2 = GameObject.Find("Cannon2").transform;
        cannon3 = GameObject.Find("Cannon3").transform;
        cannon4 = GameObject.Find("Cannon4").transform;
        fireClock = 0;
        hp = maxHP;
    }

    private void Update()
    {
        fireClock += Time.deltaTime;
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
        transform.rotation = Quaternion.identity;

        if (inputX > 0)
        {
            if (transform.position.x < bounds.position.x + bounds.localScale.x / 2)
            {
                transform.position = new Vector3(transform.position.x + inputX * speedX * Time.deltaTime, transform.position.y, 0f);
                transform.rotation = Quaternion.Euler(0f, -40f, 0f);
            }
        }
        else
        {
            if (inputX < 0)
            {
                if (transform.position.x > bounds.position.x - bounds.localScale.x / 2)
                {
                    transform.position = new Vector3(transform.position.x + inputX * speedX * Time.deltaTime, transform.position.y, 0f);
                    transform.rotation = Quaternion.Euler(0f, 40f, 0f);
                }
            }
        }

        if (inputY > 0)
        {
            if (transform.position.y < bounds.position.y + bounds.localScale.y / 2)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + inputY * speedY * Time.deltaTime, 0f);
            }
        }
        else
        {
            if (transform.position.y > bounds.position.y - bounds.localScale.y / 2)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + inputY * speedY * Time.deltaTime, 0f);
            }
        }

        if (Input.GetKey(KeyCode.H) && fireClock > fireRate)
        {
            Fire();
            fireClock = 0f;
        }
    }

    private void Fire()
    {
        Instantiate(bullet, cannon1.position, Quaternion.identity);
        Instantiate(bullet, cannon2.position, Quaternion.identity);
        Instantiate(bullet, cannon3.position, Quaternion.identity);
        Instantiate(bullet, cannon4.position, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy Bullet")
        {
            hp--;
        }
    }
}
