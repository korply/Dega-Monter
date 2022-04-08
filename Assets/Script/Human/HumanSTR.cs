using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanSTR : MonoBehaviour
{
    public int currentHealthSTR;
    public int maxHealthSTR = 100;
    public bool statusisSTRDead;
    public HearthBar healthBar;

    void Start()
    {
        currentHealthSTR = maxHealthSTR;
        healthBar.SetMaxHealth(maxHealthSTR);
        statusisSTRDead = false;
    }

   
    void Update()
    {
        if (currentHealthSTR <= 0)
        {
            statusisSTRDead = true;
            

        }
    }
    public void takeDamageSTR(int damage)
    {
        if (!statusisSTRDead)
        {
            currentHealthSTR = Mathf.Clamp(currentHealthSTR - damage, 0, maxHealthSTR);
            healthBar.Sethealth(currentHealthSTR);
        }
    }
}
