using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{


    public HumanMagic MAGhuman;
    public HumanAgi AGIhuman;
    public HumanSTR STRhuman;
    public Slot[] slots1, slots2, slots3;

    
    void Start()
    {
        slots1[0].transform.position = transform.position + new Vector3(0, 0, 0);
        slots2[0].transform.position = transform.position + new Vector3(2, 0, 0);
        slots3[0].transform.position = transform.position + new Vector3(4, 0, 0);
        MAGhuman.transform.position = transform.position + new Vector3(0, 0, 0);
        AGIhuman.transform.position = transform.position + new Vector3(2, 0, 0);
        STRhuman.transform.position = transform.position + new Vector3(4, 0, 0);

    }
    void Update()
    {
        swarplocation();
    }

    void swarplocation()
    {
        if (Input.GetKeyDown("q"))
        {
            slots1[0].transform.position = transform.position + new Vector3(4, 0, 0);
            slots2[0].transform.position = transform.position + new Vector3(2, 0, 0);
            slots3[0].transform.position = transform.position + new Vector3(0, 0, 0);
            MAGhuman.transform.position = transform.position + new Vector3(4, 0, 0);
            AGIhuman.transform.position = transform.position + new Vector3(2, 0, 0);
            STRhuman.transform.position = transform.position + new Vector3(0, 0, 0);
            Debug.Log("You have Press Q Move Blue To Front");
        }
        else if (Input.GetKeyDown("w"))
        {
            slots2[0].transform.position = transform.position + new Vector3(4, 0, 0);
            slots3[0].transform.position = transform.position + new Vector3(2, 0, 0);
            slots1[0].transform.position = transform.position + new Vector3(0, 0, 0);
            AGIhuman.transform.position = transform.position + new Vector3(4, 0, 0);
            STRhuman.transform.position = transform.position + new Vector3(2, 0, 0);
            MAGhuman.transform.position = transform.position + new Vector3(0, 0, 0);
            Debug.Log("You have Press W Move Green To Front");
        }
        else if(Input.GetKeyDown("e"))
        {
            slots3[0].transform.position = transform.position + new Vector3(4, 0, 0);
            slots1[0].transform.position = transform.position + new Vector3(0, 0, 0);
            slots2[0].transform.position = transform.position + new Vector3(2, 0, 0);
            STRhuman.transform.position = transform.position + new Vector3(4, 0, 0);
            MAGhuman.transform.position = transform.position + new Vector3(0, 0, 0);
            AGIhuman.transform.position = transform.position + new Vector3(2, 0, 0);
            Debug.Log("You have Press E Move Red To Front");
        }
        {
        }
    }
}
