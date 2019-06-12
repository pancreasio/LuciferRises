using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lucifer : MonoBehaviour
{
    public float speedX, speedY, fireRate, maxHP, positionOffset;
    private float inputX, inputY, fireClock, hp;
    public GameObject bullet;
    private GameObject model;
    public AudioSource fireSound;
    private Transform bounds, cannon1, cannon2, cannon3, cannon4, droneCannon1, droneCannon2, droneCannon3, droneCannon4, droneCannon5, droneCannon6;

    private void Start()
    {
        model = GameObject.Find("Model");
        bounds = GameObject.Find("Bounds").transform;
        cannon1 = GameObject.Find("Cannon1").transform;
        cannon2 = GameObject.Find("Cannon2").transform;
        cannon3 = GameObject.Find("Cannon3").transform;
        cannon4 = GameObject.Find("Cannon4").transform;
        droneCannon1 = GameObject.Find("Drone Cannon1").transform;
        droneCannon2 = GameObject.Find("Drone Cannon2").transform;
        droneCannon3 = GameObject.Find("Drone Cannon3").transform;
        droneCannon4 = GameObject.Find("Drone Cannon4").transform;
        droneCannon5 = GameObject.Find("Drone Cannon5").transform;
        droneCannon6 = GameObject.Find("Drone Cannon6").transform;
        fireClock = fireRate;
        hp = maxHP;
    }

    private void Update()
    {
        fireClock += Time.deltaTime;
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
        model.transform.rotation = Quaternion.identity;

        if (inputX > 0)
        {
            if (transform.position.x < bounds.position.x + bounds.localScale.x / 2)
            {
                transform.position = new Vector3(transform.position.x + inputX * speedX * Time.deltaTime, transform.position.y, 0f);
                model.transform.rotation = Quaternion.Euler(0f, -40f, 0f);
            }
            else
            {
                transform.position = new Vector3(bounds.position.x + bounds.localScale.x / 2 + positionOffset, transform.position.y, 0f);
            }
        }
        else
        {
            if (inputX < 0)
            {
                if (transform.position.x > bounds.position.x - bounds.localScale.x / 2)
                {
                    transform.position = new Vector3(transform.position.x + inputX * speedX * Time.deltaTime, transform.position.y, 0f);
                    model.transform.rotation = Quaternion.Euler(0f, 40f, 0f);
                }
                else
                {
                    transform.position = new Vector3(bounds.position.x - bounds.localScale.x / 2 - positionOffset, transform.position.y, 0f);
                }
            }
        }

        if (inputY > 0)
        {
            if (transform.position.y < bounds.position.y + bounds.localScale.y / 2)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + inputY * speedY * Time.deltaTime, 0f);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, bounds.position.y + bounds.localScale.y / 2 + positionOffset, 0f);
            }
        }
        else
        {
            if (transform.position.y > bounds.position.y - bounds.localScale.y / 2)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + inputY * speedY * Time.deltaTime, 0f);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, bounds.position.y - bounds.localScale.y / 2 - positionOffset, 0f);
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
        fireSound.Play();
        Instantiate(bullet, cannon1.position, Quaternion.identity);
        Instantiate(bullet, cannon2.position, Quaternion.identity);
        Instantiate(bullet, cannon3.position, Quaternion.identity);
        Instantiate(bullet, cannon4.position, Quaternion.identity);
        Instantiate(bullet, droneCannon1.position, Quaternion.identity);
        Instantiate(bullet, droneCannon2.position, Quaternion.identity);
        Instantiate(bullet, droneCannon3.position, Quaternion.identity);
        Instantiate(bullet, droneCannon4.position, Quaternion.identity);
        Instantiate(bullet, droneCannon5.position, Quaternion.identity);
        Instantiate(bullet, droneCannon6.position, Quaternion.identity);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy Bullet")
        {
            hp--;
        }
    }
}
