using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //public GameObject objectToSpawn;
    public List<GameObject> objectToSpawn;

    public Vector3 spawnPosition;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
        //Spawn();
    }

    private IEnumerator SpawnRoutine()
    {
        for (int licznik = 0; licznik < 10; licznik++)
        {
            yield return new WaitForSeconds(2f);

            float x = Random.Range(0f, 20f);
            float z = Random.Range(0f, 20f);

            spawnPosition = new Vector3(x, 2, z);

            GameObject enemy;
            int liczba = Random.Range(0, 2);

            enemy = objectToSpawn[liczba];

            Instantiate(enemy, spawnPosition, Quaternion.identity);
        }
    }

    public void Spawn()
    {
        //int licznik = 0;

        //do
        //{
            //licznik += 1;

            //float x = Random.Range(0f, 20f);
            //float z = Random.Range(0f, 20f);

            //spawnPosition = new Vector3(x, 2, z);

            //Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

        //} while (licznik < 10);

        for (int licznik = 0; licznik < 10; licznik++)
        {
            float x = Random.Range(0f, 20f);
            float z = Random.Range(0f, 20f);

            spawnPosition = new Vector3(x, 2, z);

            GameObject enemy;
            int liczba = Random.Range(0, 2);

            enemy = objectToSpawn[liczba];

            Instantiate(enemy, spawnPosition, Quaternion.identity);
        }
    }
}
