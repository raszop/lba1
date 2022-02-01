using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<GameObject> spawners;

    public int wave = 1;

    public float spawningDelayMultiplier;
    public int baseEnemyMultiplier;

    public float baseSpawnTime;
    public float minimumSpawnTime;

    public void StartWave()
    {
        StartCoroutine(WaveRoutine());
    }

    private IEnumerator WaveRoutine()
    {
        int enemiesToSpawn = wave * baseEnemyMultiplier;
        float timeBetweenSpawns = baseSpawnTime - ((float)wave * spawningDelayMultiplier);

        if(timeBetweenSpawns < minimumSpawnTime)
        {
            timeBetweenSpawns = minimumSpawnTime;
        }

        Debug.Log("STARTING WAVE: " + wave + " enemies: " + enemiesToSpawn + " time between spawns: " + timeBetweenSpawns);

        for(int i=0;i<enemiesToSpawn;i++)
        {
            yield return new WaitForSeconds(timeBetweenSpawns);
            GameObject spawner = spawners[Random.Range(0, spawners.Count)];
            spawner.GetComponent<Spawner>().SpawnRandomEnemy();
        }

        wave = wave + 1;
    }
}
