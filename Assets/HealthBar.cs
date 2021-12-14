using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image bar;

    public float hp;
    public float maxHp;

    // Start is called before the first frame update
    void Start()
    {
        maxHp = 100;
        hp = Random.Range(5, maxHp);
    }

    // Update is called once per frame
    void Update()
    {
        bar.fillAmount = hp / maxHp;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "kolce")
        {
            hp -= 1;
        }

        if (collision.gameObject.tag == "PlayerBullet")
        {
            hp = hp - 1;

            if (hp <= 0)
            {                
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerBullet")
        {
            hp = hp - 1;

            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
