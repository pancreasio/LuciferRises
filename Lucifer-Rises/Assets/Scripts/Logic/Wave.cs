using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public int enemyCant;
    private int spawnedEnemies;
    public float enemyDelay, enemySpeed, enemyAggression;
    private float delayClock;
    public List<Transform> waypointList;
    public GameObject cassiel;
    public Transform spawnPoint, endPoint;


    private void Start()
    {
        spawnedEnemies = 0;
        delayClock = 0;
    }

    private void Update()
    {
        delayClock += Time.deltaTime;

        if (delayClock > enemyDelay && spawnedEnemies < enemyCant)
        {
            SpawnEnemy(spawnPoint, endPoint, waypointList, enemyAggression, enemySpeed);
            spawnedEnemies++;
            delayClock = 0f;
        }
    }

    private void SpawnEnemy(Transform CspawnPoint, Transform CendPoint, List<Transform> Cwaypoints, float Caggression, float Cspeed)
    {
        GameObject cassielInstance = Instantiate(cassiel, CspawnPoint.position, Quaternion.identity);
        Cassiel cassielComponents = cassielInstance.transform.GetComponent<Cassiel>();
        cassielComponents.fireRate = Caggression;
        cassielComponents.speed = Cspeed;
        cassielComponents.endPoint = CendPoint;
        cassielComponents.waypoints = Cwaypoints;
    }
}
