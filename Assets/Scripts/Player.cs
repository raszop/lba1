using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public Text MoneyCounter;
    
    
    public Image playerHealthBar;
    public Image playerHealthBarHeart;

    public int money;
    public float hp;
    public float maxHp;

    public int damage;
    public float shootingRate;

    public void Heal(int healValue)
    {
        hp = hp + healValue;

        if(hp > maxHp)
        {
            hp = maxHp;
        }

        UpdateHealthBar();
    }

    public void GetDamage(int damageValue)
    {
        hp = hp - damageValue;

        UpdateHealthBar();

        if(hp <= 0)
        {
            //TODO
            gameObject.SetActive(false);

            //save money
            PlayerPrefs.SetInt("savedmoney", money/2);

            //reload scene
            SceneManager.LoadScene("Game_Over");

        }
    }

    private void UpdateHealthBar()
    {
        //update player's health bar on screen
        float newFillValue = hp / maxHp;
        playerHealthBar.fillAmount = newFillValue;
        playerHealthBarHeart.color = new Color(newFillValue, newFillValue, newFillValue);
    }

    private void Update()
    {
        //if(Input.GetKeyUp(KeyCode.Space))
        //{
        //    GetDamage(1);
        //}
    }
}
