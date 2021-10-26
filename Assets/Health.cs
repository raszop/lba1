using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int hp;

    [ContextMenu("try to die")]
    private void TryToDie()
    {
        if(hp < 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GetComponent<Animator>().SetTrigger("die");
    }
}
