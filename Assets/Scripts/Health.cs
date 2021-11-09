using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int hp;

    public int Hp
    {
        get => hp;
        set
        {
            hp = value;
            TryToDie();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "PlayerBullet")
        {
            Hp -= 1;
        }
    }

    public bool IsAlive()
    {
        return hp > 0;
    }

    private void TryToDie()
    {
        if(!IsAlive())
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
}
