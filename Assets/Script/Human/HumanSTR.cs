using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanSTR : MonoBehaviour
{
    public int currentHealthSTR;
    public int maxHealthSTR = 150;
    
    public HearthBar healthBar;
    void Start()
    {
        currentHealthSTR = maxHealthSTR;
        healthBar.SetMaxHealth(maxHealthSTR);
    }

   
    void Update()
    {
        if (currentHealthSTR <= 0)
        {
            //Debug.Log("STR is dead");
            
        }
    }
    public void takeDamageSTR(int damage)
    {
        currentHealthSTR -= damage;
        healthBar.Sethealth(currentHealthSTR);
    }
}
