using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoot : MonoBehaviour
{
    public int lootMaxMoney;
    public int chanceToDrop;
    public GameObject lootObject;  
    
    
    private void OnDestroy()
    {
        for(int i=0;i<lootMaxMoney;i++)
        {
            int dropChance = Random.Range(0, 100);
            if(dropChance <= chanceToDrop)
            {
                GameObject newLoot = Instantiate(lootObject, transform.position, Quaternion.identity);
            }
        }
    }
}
