using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Wave : MonoBehaviour
{
    public int enemyCant;
    private int spawnedEnemies;
    public static int totalSpawnedEnemies = 0, deadEnemies = 0;
    public float enemyDelay, enemySpeed, enemyAggression;
    private float delayClock;
    private List<Transform> waypointList, spawnPointList;
    public List<Transform> actualWaypoints;
    public List<string> waypointNames;
    public string spawnPointName, endPointName;
    public GameObject cassiel, waypoints, spawnPoints;
    public Transform spawnPoint, endPoint;
    public bool inverted = false;
    private bool listAcquired = false, spawnAcquired = false, endAcquired = false, isInverted = false;


    private void Start()
    {
        delayClock = 0;
        spawnedEnemies = 0;
        waypointList = new List<Transform>();
        spawnPointList = new List<Transform>();
        waypoints = GameObject.Find("Waypoints");
        spawnPoints = GameObject.Find("Spawn Points");
        waypointList.AddRange(waypoints.GetComponentsInChildren<Transform>());
        spawnPointList.AddRange(spawnPoints.GetComponentsInChildren<Transform>());
        waypointList = waypointList.OrderBy(tile => tile.transform.name).ToList();
        spawnPointList = spawnPointList.OrderBy(tile => tile.transform.name).ToList();
    }

    public static int SpawnedEnemies()
    {
        return totalSpawnedEnemies;
    }

    public static void EnemyDied()
    {
        deadEnemies++;
    }

    public static int DeadEnemies()
    {
        return deadEnemies;
    }

    private void Update()
    {
        
        if (waypointNames != null && !listAcquired)
        {
            actualWaypoints.Clear();
            for (int i = 0; i < waypointNames.Count; i++)
            {
                for (int i2 = 0; i2 < waypointList.Count; i2++)
                {
                    if (waypointList[i2].name == waypointNames[i])
                    {
                        actualWaypoints.Insert(i, waypointList[i2]);
                        i2 = waypointList.Count;
                    }
                }
            }
            listAcquired = true;
        }
        if (spawnPointName != null && !spawnAcquired)
        {
            for (int i = 0; i < spawnPointList.Count; i++)
            {
                if (spawnPointList[i].name == spawnPointName)
                {
                    spawnPoint = spawnPointList[i];
                    i = spawnPointList.Count;
                }
            }
            spawnAcquired = true;
        }

        if (endPointName != null && !endAcquired)
        {
            for (int i = 0; i < spawnPointList.Count; i++)
            {
                if (spawnPointList[i].name == endPointName)
                {
                    endPoint = spawnPointList[i];
                    i = spawnPointList.Count;
                }
            }
            endAcquired = true;
        }

        if (inverted && !isInverted)
        {
            actualWaypoints.Reverse();
            Transform auxTrans = spawnPoint;
            spawnPoint = endPoint;
            endPoint = auxTrans;
            isInverted = true;
        }

        delayClock += Time.deltaTime;

        if (delayClock > enemyDelay && spawnedEnemies < enemyCant)
        {
            SpawnEnemy(spawnPoint, endPoint, actualWaypoints, enemyAggression, enemySpeed);
            totalSpawnedEnemies++;
            spawnedEnemies++;
            delayClock = 0f;
        }

        if (spawnedEnemies >= enemyCant) {
            Destroy(this.gameObject);
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
