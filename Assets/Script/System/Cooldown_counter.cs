using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cooldown_counter : MonoBehaviour
{
    Text counterText;
    private ControllerMain ControllerMain;
    // Start is called before the first frame update
    void Start()
    {
        counterText = GetComponent<Text>();
        ControllerMain = GameObject.Find("NumberBox").GetComponent<ControllerMain>();

    }

    // Update is called once per frame
    void Update()
    {
        counterText.text = "Cooldown_MAG_" + Mathf.Clamp(ControllerMain.TimeRemainingMAG,0,10).ToString() + 
                            "\nCooldown_AGI_" + Mathf.Clamp(ControllerMain.TimeRemainingAGI, 0, 10).ToString() + 
                            "\nCooldown_STR_" + Mathf.Clamp(ControllerMain.TimeRemainingSTR, 0, 10).ToString(); 
    }
}
