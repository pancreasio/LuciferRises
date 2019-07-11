using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lucifer : MonoBehaviour
{
    public float speedX, speedY, fireRate, positionOffset;
    private float inputX, inputY, fireClock;
    public int droneAmmount, maxHP;
    private int  hp;
    public GameObject bullet, drone1, drone2, drone3, drone4, drone5, drone6;
    private GameObject model;
    public AudioSource fireSound;
    public Transform bounds, cannon1, cannon2, cannon3, cannon4, droneCannon1, droneCannon2, droneCannon3, droneCannon4, droneCannon5, droneCannon6;

    private void Start()
    {
        model = GameObject.Find("Model");
        bounds = GameObject.Find("Bounds").transform;
        fireClock = fireRate;
        hp = maxHP;
    }

    private void Update()
    {
        fireClock += Time.deltaTime;
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
        model.transform.rotation = Quaternion.identity;

        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }

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

        if (droneAmmount >= 2)
        {
            drone1.SetActive(true);
            drone2.SetActive(true);
        }
        else
        {
            drone1.SetActive(false);
            drone2.SetActive(false);
        }
        if (droneAmmount >= 4)
        {
            drone3.SetActive(true);
            drone4.SetActive(true);
        }
        else
        {
            drone3.SetActive(false);
            drone4.SetActive(false);
        }
        if (droneAmmount >= 6)
        {
            drone5.SetActive(true);
            drone6.SetActive(true);
        }
        else
        {
            drone5.SetActive(false);
            drone6.SetActive(false);
        }

    }

    private void Fire()
    {
        fireSound.Play();
        Instantiate(bullet, cannon1.position, Quaternion.identity);
        Instantiate(bullet, cannon2.position, Quaternion.identity);
        Instantiate(bullet, cannon3.position, Quaternion.identity);
        Instantiate(bullet, cannon4.position, Quaternion.identity);
        if (droneAmmount >= 2)
        {
            Instantiate(bullet, droneCannon1.position, Quaternion.identity);
            Instantiate(bullet, droneCannon2.position, Quaternion.identity);
        }
        if (droneAmmount >= 4)
        {
            Instantiate(bullet, droneCannon3.position, Quaternion.identity);
            Instantiate(bullet, droneCannon4.position, Quaternion.identity);
        }
        if (droneAmmount >= 6)
        {
            Instantiate(bullet, droneCannon5.position, Quaternion.identity);
            Instantiate(bullet, droneCannon6.position, Quaternion.identity);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy Bullet")
        {
            hp--;
        }
    }
}