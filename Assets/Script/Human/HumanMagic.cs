using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMagic : MonoBehaviour
{
     public int currentHealth;
    public int maxHealth = 80;
    
    public HearthBar healthBar;
    void Start()
    {
        
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            takeDamage(20);
            Debug.Log("You MAGIC have Take 20 Damage You Health is  " + currentHealth);
        }
    }
    void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.Sethealth(currentHealth);
    }
}
