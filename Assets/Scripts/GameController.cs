using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject startWaveButton;
    public List<GameObject> spawners;
    public List<GameObject> itemSpawnPlaces;
    public List<GameObject> itemsToSpawn;
    public List<GameObject> spawnedItems;

    public int wave = 1;

    public float spawningDelayMultiplier;
    public int baseEnemyMultiplier;

    public float baseSpawnTime;
    public float minimumSpawnTime;

    private float waveEndCheckTime = 2.0f;

    private void Start()
    {
        spawnedItems = new List<GameObject>();
    }
    public void StartWave()
    {
        StartCoroutine(WaveRoutine());
    }

    private IEnumerator WaveRoutine()
    {
        DespawnItemsToBuy();
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
        StartCoroutine(CheckIfWaveEndedRoutine());
    }

    private IEnumerator CheckIfWaveEndedRoutine()
    {
        GameObject[] enemies;
        do
        {
            yield return new WaitForSeconds(waveEndCheckTime);
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
        } while (enemies.Length > 0);

        if (enemies.Length == 0)
        {
            Debug.Log("Wave ended");
            ShowStartWaveButton();
            SpawnItemsToBuy();
        }
    }

    private void ShowStartWaveButton()
    {
        startWaveButton.gameObject.SetActive(true);
    }

    [ContextMenu("spawn items")]
    private void SpawnItemsToBuy()
    {
        foreach(GameObject place in itemSpawnPlaces)
        {
            GameObject newItem = Instantiate(itemsToSpawn[Random.Range(0, itemsToSpawn.Count)], place.transform.position, Quaternion.identity);
            spawnedItems.Add(newItem);
        }
    }

    [ContextMenu("despawn items")]
    private void DespawnItemsToBuy()
    {
        foreach(GameObject item in spawnedItems)
        {
            DestroyImmediate(item);
        }

        spawnedItems = new List<GameObject>();
    }
}
