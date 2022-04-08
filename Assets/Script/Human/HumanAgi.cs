using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanAgi : MonoBehaviour
{
    public int currentHealthAgi;
    public int maxHealthAgi = 100;
    public bool statusisAGIDead;
    public HearthBar healthBar;

    void Start()
    {
        currentHealthAgi = maxHealthAgi;
        healthBar.SetMaxHealth(maxHealthAgi);
        statusisAGIDead = false;
    }
    void Update()
    {
        if (currentHealthAgi <= 0)
        {
            statusisAGIDead = true;
            

        }
    }

    public void takeDamageAgi(int damage)
    {
        if (!statusisAGIDead)
        {
            currentHealthAgi = Mathf.Clamp(currentHealthAgi - damage, 0, maxHealthAgi);
            healthBar.Sethealth(currentHealthAgi);
        }
    }
}
