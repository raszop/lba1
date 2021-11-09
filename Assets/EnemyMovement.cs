using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField]
    private Health health;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(ChasePlayerRoutine());
    }

    private IEnumerator ChasePlayerRoutine()
    {
        do
        {
            yield return new WaitForSeconds(1.0F);

            agent.SetDestination(player.transform.position);

        } while (health.IsAlive());
    }
}
