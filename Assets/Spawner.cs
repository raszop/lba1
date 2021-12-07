using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;

    public Vector3 spawnPosition;

    public void Spawn()
    {
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }

    private void Update()
    {
        //Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        Spawn();
    }
}
