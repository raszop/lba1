using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;

    public int healHpValue;

    public int additionalHealth;
    public int additionalDamage;
    public int additionalShootingRate;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<Player>().Heal(healHpValue);
            other.GetComponent<Player>().maxHp += additionalHealth;

            Destroy(this.gameObject);
        }
    }
}
