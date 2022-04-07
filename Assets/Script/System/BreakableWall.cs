using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    //get controller ref
    public ControllerMain ControllerMain;
    void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;
        ControllerMain = GameObject.Find("NumberBox").GetComponent<ControllerMain>();
    }


    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D c2d)
    {
        //Destroy the coin if Object tagged Player comes in contact with it
        if (c2d.CompareTag("Player") && ControllerMain.statusisSTR)
        {

            //Destroy coin
            Destroy(gameObject);
        }
    }
}

