using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] int _spawnBossAfterWave;
    [SerializeField] GameObject bossPrefab;
    public EnemyWave[] enemyWaves;

    private int currentWave;

    // Start is called before the first frame update
    void Start() {
        EnemyHealth.LivingEnemyCount++;
        SpawnEnemyWave();
    }

    private void SpawnEnemyWave()
    {
        var waveInfo = enemyWaves[currentWave];
        for (int i = 0; i < waveInfo.numberOfEnemy; i++)
        {
            var enemy = Instantiate(waveInfo.enemyPrefab);
            var agent = enemy.GetComponent<FlyPathAgent>();
            agent.splineComputer = waveInfo.splineComputer;
            agent.flySpeed = waveInfo.speed;
            agent.EnableEnemy(waveInfo.timeOffset * i);
        }
        currentWave++;
        if (currentWave < enemyWaves.Length)
        {
            Invoke(nameof(SpawnEnemyWave), waveInfo.nextWaveDelay);
        }
        if (currentWave == enemyWaves.Length-1)
        {
            EnemyHealth.LivingEnemyCount--;
        }
        if(currentWave == _spawnBossAfterWave)
        {
            SpawnBoss();
        }
    }

    void SpawnBoss()
    {
        Instantiate(bossPrefab);
    }
}



