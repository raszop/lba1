using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragon : MonoBehaviour
{
    public int damage;
    public int hp;
    public void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.tag == "Player")
        {
            Collision.gameObject.GetComponent<Player>().GetDamage(damage);

        }
    }
}
