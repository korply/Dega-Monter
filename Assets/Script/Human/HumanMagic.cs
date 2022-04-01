using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMagic : MonoBehaviour
{
    public int currentHealthMagic;
    public int maxHealthMagic = 80;

    public HearthBar healthBar;
    void Start()
    {

        currentHealthMagic = maxHealthMagic;
        healthBar.SetMaxHealth(maxHealthMagic);
    }


    void Update()
    {
        if (currentHealthMagic <= 0)
        {
            Debug.Log("MAGIC is dead");
            
        }
    }
    public void takeDamageMagic(int damage)
    {
        currentHealthMagic -= damage;
        healthBar.Sethealth(currentHealthMagic);
    }
}
