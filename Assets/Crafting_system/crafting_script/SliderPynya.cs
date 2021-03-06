using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderPynya : MonoBehaviour
{
    //slider asset
    public Slider mainSlider;
    public Slider QISlider;
    public BoxCollider2D BoxCollider2DGray;
    public BoxCollider2D BoxCollider2DBlue;
    public BoxCollider2D BoxCollider2DHandler;
    bool B;
    bool G;
    public Rigidbody2D Rigidbody2DGray;
    

    //start bar movement
    public bool startTheBar=false;
    private bool addValue = true;

    //bar move speed
    public float variableToChange=1;
    public float startBarSpeed;
    public float maxBarSpeed;
    private float acceleratePerSecond = 0.25f;

    //target for click
    public GameObject targetPrefab;
    public bool spawnPhase = false;
    public bool spawnable=false;
    //count target
    public int totalTargetCount;
    //target animation speed
    public float targetChangePersecondByBarHit;
 

    //score
    public int badhit;
    public int goodhit;
    public int perfecthit;
    public string feedbackText;
    public Text feedbackTextUI;


    //game over
    public bool gameIsOver = false;
    public string finalScore_string;
    public Text finalScoreTextUI;

    //setQI to speed
    public float CraftItemQI = 1;
    public float minBarSpeed;
    public float MaxBarSpeed;
    public float minTargetSpeed;
    public float maxTargetSpeed;
    public Text QITextUI;



    private void Start()
    {
        RandomBarLocation();
    }



    void Update()
    {
        //Update realtime value
        CraftItemQI = QISlider.value;
        QITextUI.text = CraftItemQI.ToString();
        feedbackTextUI.text = feedbackText;

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
        if(totalTargetCount==5)
        {
            gameIsOver = true;
            finalScore_string = "CraftItemQI_"+CraftItemQI +"\nbad_" + badhit + " good_" + goodhit + " perfect_" + perfecthit;
            finalScoreTextUI.text = finalScore_string;
        }

    }


    //check hit area miss/hit blue
    private void CheckhitArea()
    {

        
        B = BoxCollider2DBlue.IsTouching(BoxCollider2DHandler);
        G = BoxCollider2DGray.IsTouching(BoxCollider2DHandler);

        if (B&&G)
            {
            // hit blue
            Debug.Log("hit blue");
            feedbackText = "hit blue!!!";
            spawnable = true;
            spawnPhase = true;
            targetChangePersecondByBarHit = minTargetSpeed;
        }
        if(G&&!B)
        {
            //miss
            Debug.Log("miss");
            feedbackText = "miss!";
            startTheBar = true;
            RandomBarLocation();
            SetCraftedItemQIToSpeed();
            Debug.Log("bad_" + badhit + " good_" + goodhit + " perfect_" + perfecthit);
        }
        if(!G&&!B)
        {
            //miss
            Debug.Log("miss");
            feedbackText = "miss!";
            startTheBar = true;
            RandomBarLocation();
            SetCraftedItemQIToSpeed();
            Debug.Log("bad_" + badhit + " good_" + goodhit + " perfect_" + perfecthit);
        }

        
     
    }

    //get QI input to bar speed
    public void SetCraftedItemQIToSpeed()
    {
        if(CraftItemQI<=25)
        {
            startBarSpeed = 50;
            maxBarSpeed = 150;
        }
        if(CraftItemQI>25 && CraftItemQI<=50)
        {
            startBarSpeed = 71;
            maxBarSpeed = 150;
        }
        if(CraftItemQI>50 && CraftItemQI<=75)
        {
            startBarSpeed = 91;
            maxBarSpeed = 150;
        }
        if(CraftItemQI>75 && CraftItemQI<=89)
        {
            startBarSpeed = 100;
            maxBarSpeed = 150;
        }
        if(CraftItemQI>=90)
        {
            startBarSpeed = 120;
            maxBarSpeed = 180;
        }

        //scale Bar
        //1 - 25 = 50 - 150
        //26 - 50 = 71 - 150
        //51 - 75 = 91 - 150
        //76 - 89 = 100 - 150
        //90 - 100 = 120 - 180


        if(CraftItemQI>=1&&CraftItemQI<=50)
        {
            minTargetSpeed = 1;
            maxTargetSpeed = 3;
        }
        if(CraftItemQI>50&&CraftItemQI<=89)
        {
            minTargetSpeed = 3;
            maxTargetSpeed = 4;
        }
        if(CraftItemQI>=90)
        {
            minTargetSpeed = 5;
            maxTargetSpeed = 5;
        }
        //scale target
        //1 - 50 = 1,3
        //51 - 89 = 2,4
        //90 - 100 = 3,5
        
    }

    //spawn target on screen
    public void spawnTarget()
    {
        
        GameObject target = Instantiate(targetPrefab) as GameObject;

        //random spawn position
        target.transform.position = new Vector2(Random.Range(-4, 4), Random.Range(0, 3));
        spawnable = false;
        SetCraftedItemQIToSpeed();

    }

    //random local location of bar
    public void RandomBarLocation()
    {
        Rigidbody2DGray.transform.localPosition = new Vector2(Random.Range(-250, 250), 0);
    }

    void FixedUpdate()
    {
        //bar movement
        if (startTheBar)
        {
            //speed with limited speed
            startBarSpeed = Mathf.Clamp(startBarSpeed + acceleratePerSecond, 1, maxBarSpeed);

            //movement acceleration
            if (addValue)
            {
                variableToChange += startBarSpeed * Time.deltaTime;
                mainSlider.value = variableToChange;
                if (variableToChange > 99)
                    addValue = false;
            }
            else
            {
                variableToChange -= startBarSpeed * Time.deltaTime;
                mainSlider.value = variableToChange;
                if (variableToChange < 1)
                    addValue = true;
            }
            
        }

    }
}
