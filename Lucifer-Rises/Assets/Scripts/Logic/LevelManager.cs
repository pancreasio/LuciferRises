using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelManager : MonoBehaviour
{
    public enum WaveType
    {
        azraelS, azraelU, hadraniel, abaddon, vWave, wWave, oWave, siWave, vWaveI, wWaveI, oWaveI, siWaveI
    }

    [System.Serializable]
    public class EnemyWave
    {
        public WaveType waveType;
        public float time;
        public string spawnPoint;
        public GameObject target;
        public bool spawned;
    }

    public GameObject cassielPrefab, azraelSPrefab, azraelUPrefab, hadranielPrefab, abaddonPrefab, vWavePrefab, wWavePrefab, oWavePrefab, siWavePrefab;
    public List<EnemyWave> waves;
    public bool levelEnded;
    private float lastWaveTime, levelTime;


    private void Start()
    {
        levelTime = 0.0f;
        lastWaveTime = 0.0f;
        if (waves == null)
        {
            waves = new List<EnemyWave>();
        }

        for (int i = 0; i < waves.Count; i++)
        {
            waves[i].spawned = false;
            if (waves[i].time > lastWaveTime)
            {
                lastWaveTime = waves[i].time;
            }
        }
    }

    private void Update()
    {
        levelTime += Time.deltaTime;

        foreach (EnemyWave waveCount in waves)
        {
            if (waveCount.time <= levelTime && !waveCount.spawned)
            {
                SpawnWave(waveCount);
                waveCount.spawned = true;
            }
        }

        if (levelTime > lastWaveTime)
        {
            if (Wave.deadEnemies >= Wave.totalSpawnedEnemies)
            {
                levelEnded = true;
            }
        }
    }

    private void SpawnWave(EnemyWave wave)
    {
        GameObject waveToSpawn = new GameObject();
        bool cassielWave = false;
        switch (wave.waveType)
        {
            case WaveType.azraelS:
                waveToSpawn = azraelSPrefab;
                break;
            case WaveType.azraelU:
                waveToSpawn = azraelUPrefab;
                waveToSpawn = Instantiate(azraelUPrefab, GameObject.Find(wave.spawnPoint).transform.position, Quaternion.identity);
                break;
            case WaveType.hadraniel:
                waveToSpawn = hadranielPrefab;
                waveToSpawn.GetComponent<Hadraniel>().endPoint = wave.target.transform;
                waveToSpawn = Instantiate(hadranielPrefab, GameObject.Find(wave.spawnPoint).transform.position, Quaternion.identity);
                break;
            case WaveType.abaddon:
                waveToSpawn = abaddonPrefab;
                waveToSpawn.GetComponent<Abaddon>().endPoint = wave.target.transform;
                waveToSpawn = Instantiate(abaddonPrefab, GameObject.Find(wave.spawnPoint).transform.position, Quaternion.identity);
                break;
            case WaveType.vWave:
                waveToSpawn = vWavePrefab;
                cassielWave = true;
                break;
            case WaveType.wWave:
                waveToSpawn = wWavePrefab;
                cassielWave = true;
                break;
            case WaveType.oWave:
                waveToSpawn = oWavePrefab;
                cassielWave = true;
                break;
            case WaveType.siWave:
                waveToSpawn = siWavePrefab;
                cassielWave = true;
                break;
            case WaveType.vWaveI:
                waveToSpawn = vWavePrefab;
                waveToSpawn.GetComponent<Wave>().inverted = true;
                cassielWave = true;
                break;
            case WaveType.wWaveI:
                waveToSpawn = wWavePrefab;
                waveToSpawn.GetComponent<Wave>().inverted = true;
                cassielWave = true;
                break;
            case WaveType.oWaveI:
                waveToSpawn = oWavePrefab;
                waveToSpawn.GetComponent<Wave>().inverted = true;
                cassielWave = true;
                break;
            case WaveType.siWaveI:
                waveToSpawn = siWavePrefab;
                waveToSpawn.GetComponent<Wave>().inverted = true;
                cassielWave = true;
                break;
            default:
                break;
        }
        if (cassielWave)
        {
            Instantiate(waveToSpawn);
        }
    }
}
