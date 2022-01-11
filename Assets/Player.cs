using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Image playerHealthBar;

    public float hp;
    public float maxHp;

    public void Heal(int healValue)
    {
        hp = hp + healValue;

        if(hp > maxHp)
        {
            hp = maxHp;
        }

        //update player's health bar on screen
        playerHealthBar.fillAmount = hp / maxHp;
    }

    public void GetDamage(int damageValue)
    {
        hp = hp - damageValue;

        //update player's health bar on screen
        playerHealthBar.fillAmount = hp / maxHp;

        if(hp <= 0)
        {
            //TODO
        }
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            GetDamage(1);
        }
    }
}
