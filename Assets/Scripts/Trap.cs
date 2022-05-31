using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public GameObject kolce;

    public int damage;

    public float destroyTime;

    private void Start()
    {
        Invoke(nameof(DestroySpikeTrap), destroyTime);
    }

    private void DestroySpikeTrap()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<HealthBar>().hp -= damage;       
        }

        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().GetDamage(damage);
        }
        kolce.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        kolce.SetActive(false);
    }
}