using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMagic : MonoBehaviour
{
    public int currentHealthMagic;
    public int maxHealthMagic = 100;
    public bool statusisMAGICDead;
    public HearthBar healthBar;

    void Start()
    {

        currentHealthMagic = maxHealthMagic;
        healthBar.SetMaxHealth(maxHealthMagic);
        statusisMAGICDead = false;
    }


    void Update()
    {
        if (currentHealthMagic <= 0)
        {
            statusisMAGICDead = true;
            

        }
    }
    public void takeDamageMagic(int damage)
    {
        if (!statusisMAGICDead)
        {
            currentHealthMagic = Mathf.Clamp(currentHealthMagic - damage, 0, maxHealthMagic);
            healthBar.Sethealth(currentHealthMagic);
        }
    }
}
