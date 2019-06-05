using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lucifer : MonoBehaviour
{
    public float speedX, speedY, fireRate;
    private float inputX, inputY, fireClock;
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
    }

    private void Update()
    {
        fireClock += Time.deltaTime;
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        if (inputX > 0)
        {
            if (transform.position.x < bounds.position.x + bounds.localScale.x / 2)
            {
                transform.position = new Vector3(transform.position.x + inputX * speedX * Time.deltaTime, transform.position.y, 0f);
            }
        }
        else
        {
            if (transform.position.x > bounds.position.x - bounds.localScale.x / 2)
            {
                transform.position = new Vector3(transform.position.x + inputX * speedX * Time.deltaTime, transform.position.y, 0f);
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
        }
    }

    private void Fire()
    {
        Instantiate(bullet, cannon1.position, Quaternion.identity);
        Instantiate(bullet, cannon2.position, Quaternion.identity);
        Instantiate(bullet, cannon3.position, Quaternion.identity);
        Instantiate(bullet, cannon4.position, Quaternion.identity);
    }
}
