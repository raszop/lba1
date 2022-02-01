using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField]
    private HealthBar health;

    public GameObject target;

    private void Start()
    {
        if(target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }        
    }

    private void Update()
    {
        if(health.hp > 0)
        {
            agent.SetDestination(target.transform.position);
        }
    }
}
