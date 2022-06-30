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
    public float changePersecondByBarHit;

    public bool startTheBar=false;
    private bool addValue = true;

    public GameObject targetPrefab;


    public float variableToChange=1;
    public float changePerSecond=120;
    private float acceleratePerSecond = 0.25f;

    public bool spawnPhase = false;
    public bool spawnable=false;
    public int totalTargetCount;

    //score
    public int badhit;
    public int goodhit;
    public int perfecthit;

    private void Start()
    {
        RandomBarLocation();
        
    }

    void Update()
    {
        
        //space to start bar 
        if (Input.GetKeyDown(KeyCode.Space) && !spawnPhase && totalTargetCount < 5)
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
                CheckhitArea();
            }

        }

        //generate target for click till count 5
        if(spawnPhase&&spawnable&&totalTargetCount<5)
        {
            spawnTarget();
        }

    }


    private void CheckhitArea()
    {

        
        B = BoxCollider2DBlue.IsTouching(BoxCollider2DHandler);
        G = BoxCollider2DGray.IsTouching(BoxCollider2DHandler);

        if (B&&G)
            {
            // hit blue
            Debug.Log("hit blue");
            
            spawnable = true;
            spawnPhase = true;
            changePersecondByBarHit = 3;
        }
        if(G&&!B)
        {
            // hit gray
            Debug.Log("hit gray");
            
            spawnable = true;
            spawnPhase = true;
            changePersecondByBarHit = 5;
        }
        if(!G&&!B)
        {
            //miss
            Debug.Log("miss");
            badhit++;
            totalTargetCount++;
            Debug.Log("bad_" + badhit + " good_" + goodhit + " perfect_" + perfecthit);
        }

        
     
    }

    public void spawnTarget()
    {
        totalTargetCount++;
        GameObject target = Instantiate(targetPrefab) as GameObject;
        target.transform.position = new Vector2(Random.Range(-4, 4), Random.Range(-1, 2));
        spawnable = false;
        changePerSecond = 120;

    }

    public void RandomBarLocation()
    {
        Rigidbody2DGray.transform.localPosition = new Vector2(Random.Range(-250, 250), 0);
    }

    void FixedUpdate()
    {

        if (startTheBar)
        {

            changePerSecond = Mathf.Clamp(changePerSecond + acceleratePerSecond, 1, 180);

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
