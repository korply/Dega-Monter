using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderPynya : MonoBehaviour
{
    public Slider mainSlider;
    private bool startTheBar=false;
    private bool addValue = true;

    public GameObject targetPrefab;

    public bool useFixedUpdate;
    public float variableToChange=1;
    private float changePerSecond=30;

    private bool spawnPhase = false;
    public bool spawnable=false;
    public int totalTargetCount;

    void Update()
    {
        

        if (!useFixedUpdate && startTheBar)
        {
            if(addValue)
            {
                variableToChange += changePerSecond * Time.deltaTime;
                mainSlider.value = variableToChange;
                if (variableToChange > 100)
                    addValue = false;            }
            else
            {
                variableToChange -= changePerSecond * Time.deltaTime;
                mainSlider.value = variableToChange;
                if (variableToChange < 2)
                    addValue = true;
            }
            
        }

        if (Input.GetKeyDown(KeyCode.Space) && !spawnPhase)
        {
            if (!startTheBar)
            {
                startTheBar = true;
            }
            else
            { 
                startTheBar = false;
                Checkpunya();
            }

        }

        if(spawnPhase&&spawnable&&totalTargetCount<5)
        {
            spawnTarget();
        }

    }


    private void Checkpunya()
    {
        totalTargetCount = 0;
        spawnable = true;
        spawnPhase = true;
     
    }

    public void spawnTarget()
    {
        totalTargetCount++;
        GameObject target = Instantiate(targetPrefab) as GameObject;
        target.transform.position = new Vector2(Random.Range(-3, 3), Random.Range(-2, 3));
        spawnable = false;
    }


    void FixedUpdate()
    {

        if (useFixedUpdate && startTheBar)
        {
            if (addValue)
            {
                variableToChange += changePerSecond * Time.deltaTime;
                mainSlider.value = variableToChange;
                if (variableToChange > 99)
                    addValue = false;
            }
            else
            {
                variableToChange -= changePerSecond * Time.deltaTime;
                mainSlider.value = variableToChange;
                if (variableToChange < 1)
                    addValue = true;
            }
        }

    }
}
