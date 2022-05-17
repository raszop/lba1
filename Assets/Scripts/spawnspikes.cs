using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnspikes : MonoBehaviour
{
    public GameObject objectToSpawn;

    public Vector3 spawnPosition;

    public float spawnTime;

    public float spawnDistanceMax;
    public float spawnDistanceMin;

    private void Start()
    {
        //StartCoroutine(SpawnRoutine());
        SpawnSpikes();
    }

    [ContextMenu("test spawn trap")]
    public void SpawnSpikes()
    {
        GameObject newTrap = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 playerPosition = player.transform.position;

        float distanceToPlayer = 0;
        Vector3 finalPosition = new Vector3();
        do
        {
            Vector3 insideSpherePosition = playerPosition + Random.insideUnitSphere * spawnDistanceMax;

            finalPosition = new Vector3();
            finalPosition.x = insideSpherePosition.x;
            finalPosition.y = playerPosition.y;
            finalPosition.z = insideSpherePosition.z;

            distanceToPlayer = Vector3.Distance(playerPosition, finalPosition);

        } while (distanceToPlayer < spawnDistanceMin);

        newTrap.transform.position = finalPosition;



        Invoke("SpawnSpikes", spawnTime);
    }



}


    



           