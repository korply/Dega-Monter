using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource_Orb : MonoBehaviour
{
    //Keep track of total picked coins (Since the value is static, it can be accessed at "SC_2DCoin.totalCoins" from any script)
    public static int totalOrbs = 0;

    void Awake()
    {
        //Make Collider2D as trigger 
        GetComponent<Collider2D>().isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D c2d)
    {
        //Destroy the coin if Object tagged Player comes in contact with it
        if (c2d.CompareTag("Player"))
        {
            //Add to counter
            totalOrbs++;

            //Destroy 
            Destroy(this.gameObject);
        }
    }
}