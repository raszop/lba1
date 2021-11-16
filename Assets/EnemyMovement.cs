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

    private bool canMove;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(ChasePlayerRoutine());
    }

    public void ToggleMovement()
    {
        canMove = !canMove;
    }

    private IEnumerator ChasePlayerRoutine()
    {
        do
        {
            yield return new WaitForSeconds(1.0F);

            if (canMove)
            {
                agent.SetDestination(player.transform.position);
            }
            else
            {
                agent.SetDestination(transform.position);
            }
            //gameObject.transform.position = player.transform.position;

        } while (health.IsAlive());
    }
}
