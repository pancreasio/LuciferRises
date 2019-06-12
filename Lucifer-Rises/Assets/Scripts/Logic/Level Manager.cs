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

    public class EnemyWave
    {
        public WaveType wave;
        public float time;
        public bool spawned;
    }

    public GameObject cassielPrefab, azraelSPrefab, azraelUPrefab, hadranielPrefab, abaddonPrefab, vWavePrefab, wWavePrefab, oWavePrefab, siWavePrefab;
    public List<EnemyWave> waves;
    private float lastWaveTime;

    private void Start()
    {
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

    }







}
