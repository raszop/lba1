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
    [SerializeField]
    private Rigidbody rb;

    public GameObject target;

    private void Start()
    {
        if(target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }

        if(rb == null)
        {
            rb = GetComponent<Rigidbody>();
            rb.isKinematic = false;
        }
    }

    private void Update()
    {
        if(health.hp > 0)
        {
            rb.velocity = Vector3.zero;
            agent.SetDestination(target.transform.position);
        }
    }
}
