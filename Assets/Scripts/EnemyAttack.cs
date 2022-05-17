using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage;
    public float attackDelay = 1.0f;
    public  bool canAttackPlayer;

    private Player player;

    private float nextAttack = 0.0f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(player == null)
            {
                player = collision.gameObject.GetComponent<Player>();
            }

            canAttackPlayer = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            canAttackPlayer = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        nextAttack += Time.deltaTime;

        if(canAttackPlayer == true)
        {
            if(nextAttack >= attackDelay)
            {
                if (player != null)
                {
                    player.GetDamage(damage);
                }
                nextAttack = 0.0f;
                Debug.Log("ATTACKING PLAYER!");
            }
        }
    }
}
