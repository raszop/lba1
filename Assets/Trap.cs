using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enenmy")
        {
            collision.gameObject.GetComponent<HealthBar>().hp -= damage;       
        }

        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().GetDamage(damage);
        }
    }
}