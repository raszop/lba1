using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public GameObject projectile;
    public float bulletSpeed;

    private GameObject player;

    public float attackDelay = 1.0f;

    private float nextAttack = 0.0f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        nextAttack += Time.deltaTime;

        if (nextAttack >= attackDelay)
        {
            nextAttack = 0.0f;
            Shoot();
        }
    }

    public void Shoot()
    {
        GameObject newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
        newProjectile.transform.LookAt(player.transform);
        newProjectile.GetComponent<Rigidbody>().AddForce(newProjectile.transform.TransformDirection(Vector3.forward) * bulletSpeed);
    }
}
