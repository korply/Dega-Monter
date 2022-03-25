using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HumanAgi : MonoBehaviour
{
    
    public int currentHealth;
    public int maxHealth = 100;
    
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
            Debug.Log("You AGI have Take 20 Damage You Health is  " + currentHealth);
        }
        
    }

    void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.Sethealth(currentHealth);
    }
}
