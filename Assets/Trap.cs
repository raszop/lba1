using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public float hp;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enenmy")
        {
            collision.gameObject.GetComponent<HealthBar>().hp -= 1;
            hp -= 1;        
        }
    }
}