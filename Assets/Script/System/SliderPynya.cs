using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderPynya : MonoBehaviour
{
    public Slider mainSlider;
    public BoxCollider2D BoxCollider2DGray;
    public BoxCollider2D BoxCollider2DBlue;
    public BoxCollider2D BoxCollider2DHandler;
    bool B;
    bool G;
    public Rigidbody2D Rigidbody2DGray;

    private bool startTheBar=false;
    private bool addValue = true;

    public GameObject targetPrefab;

    public bool useFixedUpdate;
    public float variableToChange=1;
    public float changePerSecond=60;
    private float acceleratePerSecond = 0.25f;

    private bool spawnPhase = false;
    public bool spawnable=false;
    public int totalTargetCount;



    private void Start()
    {
        Rigidbody2DGray.transform.localPosition = new Vector2(Random.Range(-250, 250), 0);
    }

    void Update()
    {
        

        if (!useFixedUpdate && startTheBar)
        {
            if(addValue)
            {
                changePerSecond = changePerSecond + acceleratePerSecond;
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
                //first spacebar hit
                startTheBar = true;
            }
            else
            { 
                //second spacebar hit
                startTheBar = false;
                Checkhit();
            }

        }

        if(spawnPhase&&spawnable&&totalTargetCount<5)
        {
            spawnTarget();
        }

    }


    private void Checkhit()
    {


       B = BoxCollider2DBlue.IsTouching(BoxCollider2DHandler);
        G = BoxCollider2DGray.IsTouching(BoxCollider2DHandler);

        if (B&&G)
            {
            // hit blue
            Debug.Log("hit blue");
            totalTargetCount = 0;
            spawnable = true;
            spawnPhase = true;
        }
        if(G&&!B)
        {
            // hit gray
            Debug.Log("hit gray");
            totalTargetCount = 0;
            spawnable = true;
            spawnPhase = true;
        }
        if(!G&&!B)
        {
            //miss
            Debug.Log("miss");
        }

        
     
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

            changePerSecond = Mathf.Clamp(changePerSecond + acceleratePerSecond, 1, 150);

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
