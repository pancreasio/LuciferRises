using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lucifer : MonoBehaviour
{
    public float speedX, speedY, fireRate, positionOffset, iTime;
    private float inputX, inputY, fireClock, iClock, intermitentClock;
    private bool invulnerable;
    public int droneAmmount, maxHP;
    private int  hp;
    public GameObject bullet, drone1, drone2, drone3, drone4, drone5, drone6, droneExplosion;
    private GameObject model;
    public Image healthbar;
    public AudioSource fireSound;
    public Transform bounds, cannon1, cannon2, cannon3, cannon4, droneCannon1, droneCannon2, droneCannon3, droneCannon4, droneCannon5, droneCannon6;

    private void Start()
    {
        model = GameObject.Find("Model");
        bounds = GameObject.Find("Bounds").transform;
        fireClock = fireRate;
        hp = maxHP;
        invulnerable = false;
        iClock = 0;
        intermitentClock = 0;
    }

    private void Update()
    {
        fireClock += Time.deltaTime;
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        model.transform.rotation = Quaternion.identity;

        healthbar.rectTransform.sizeDelta = new Vector2(healthbar.rectTransform.sizeDelta.x, hp * 20.0f);

        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }

        if (invulnerable)
        {            
            iClock += Time.deltaTime;
            intermitentClock += Time.deltaTime;
            if (intermitentClock >= 0.1f)
            {
                model.SetActive(!model.activeSelf);
                intermitentClock = 0;
            }

            if (iClock >= iTime)
            {
                model.SetActive(true);
                invulnerable = false;
                iClock = 0;
                intermitentClock = 0;
            }
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

        if (Input.GetKeyDown(KeyCode.K) && droneAmmount >=2)
        {
            DetonateDrones();
        }

        if (droneAmmount >= 8)
        {
            droneAmmount = 6;
        }
        else
        {
            if (droneAmmount <= 0)
            {
                droneAmmount = 0;
            }
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

    private void DetonateDrones()
    {
        droneAmmount -= 2;
        GameObject[] bulletList = GameObject.FindGameObjectsWithTag("Enemy Bullet");
        foreach (GameObject bullet in bulletList)
        {
            Destroy(bullet.gameObject);
        }
        Instantiate(droneExplosion, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy Bullet")
        {
            if (!invulnerable)
            {
                hp--;
                droneAmmount -= 2;
                invulnerable = true;
            }
        }
        if (collision.transform.tag == "Powerup")
        {
            droneAmmount += 2;
        }
    }
}