using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanAgi : MonoBehaviour
{
    public int currentHealthAgi;
    public int maxHealthAgi = 100;
    public float coolDown;
    float lastSwap;
    
    public HearthBar healthBar;
    void Start()
    {
        currentHealthAgi = maxHealthAgi;
        healthBar.SetMaxHealth(maxHealthAgi);
    }
    void Update()
    {
        if (maxHealthAgi <= 0)
        {
            //Debug.Log("AGI is dead");
            
        }
    }

    public void takeDamageAgi(int damage)
    {
        currentHealthAgi -= damage;
        healthBar.Sethealth(currentHealthAgi);
    }
}
