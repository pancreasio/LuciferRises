﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelManager : MonoBehaviour
{
    public enum WaveType
    {
        azraelS, azraelU, hadraniel, abaddon, vWave, wWave, oWave, siWave, vWaveI, wWaveI, oWaveI, siWaveI
    }

    public class EnemyWave
    {
        public WaveType waveType;
        public float time;
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
            if (waveCount.time >= levelTime && !waveCount.spawned)
            {
                SpawnWave(waveCount);
                waveCount.spawned = true;
            }
        }

        if (levelTime > lastWaveTime)
        {
            if (Wave.deadEnemies >= Wave.spawnedEnemies)
            {
                levelEnded = true;
            }
        }
    }

    private void SpawnWave(EnemyWave wave)
    {
        GameObject waveToSpawn = new GameObject();
        switch (wave.waveType)
        {
            case WaveType.azraelS:
                waveToSpawn = azraelSPrefab;
                break;
            case WaveType.azraelU:
                waveToSpawn = azraelUPrefab;
                break;
            case WaveType.hadraniel:
                waveToSpawn = hadranielPrefab;
                break;
            case WaveType.abaddon:
                waveToSpawn = abaddonPrefab;
                break;
            case WaveType.vWave:
                waveToSpawn = vWavePrefab;
                break;
            case WaveType.wWave:
                waveToSpawn = wWavePrefab;
                break;
            case WaveType.oWave:
                waveToSpawn = oWavePrefab;
                break;
            case WaveType.siWave:
                waveToSpawn = siWavePrefab;
                break;
            case WaveType.vWaveI:
                waveToSpawn = vWavePrefab;
                waveToSpawn.GetComponent<Wave>().inverted = true;
                break;
            case WaveType.wWaveI:
                waveToSpawn = wWavePrefab;
                waveToSpawn.GetComponent<Wave>().inverted = true;
                break;
            case WaveType.oWaveI:
                waveToSpawn = oWavePrefab;
                waveToSpawn.GetComponent<Wave>().inverted = true;
                break;
            case WaveType.siWaveI:
                waveToSpawn = siWavePrefab;
                waveToSpawn.GetComponent<Wave>().inverted = true;
                break;
            default:
                break;
        }
        Instantiate(waveToSpawn);
    }
}