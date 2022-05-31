using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoneyPickup : MonoBehaviour
{
    [SerializeField]
    private int moneyValue;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().money += moneyValue;
            other.gameObject.GetComponent<Player>().MoneyCounter.text = other.gameObject.GetComponent<Player>().money.ToString();
            Destroy(this.gameObject);
        }
    }
}
