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

    public GameObject target;

    private void Start()
    {
        if(target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }

        StartCoroutine(ChasePlayerRoutine());
    }

    private IEnumerator ChasePlayerRoutine()
    {
        do
        {
            yield return new WaitForSeconds(1.0F);

            //gameObject.transform.position = player.transform.position;
            agent.SetDestination(target.transform.position);

        } while (health.IsAlive());
    }
}
