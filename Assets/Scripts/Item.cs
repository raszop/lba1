using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;

    public int itemCost;

    public int healHpValue;

    public int additionalHealth;
    public int additionalDamage;
    public float additionalShootingRate;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (other.gameObject.GetComponent<Player>().money >= itemCost)
            {
                Player player = other.GetComponent<Player>();

                player.Heal(healHpValue);
                player.maxHp += additionalHealth;
                player.damage += additionalDamage;
                player.shootingRate += additionalShootingRate;

                Destroy(this.gameObject);
            }
        }
    }
}
