using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetForSmith : MonoBehaviour
{
    public SliderPynya sliderPynya;

    public GameObject GameObjectFade;

    private float scale=3;
    private float changePerSecond;

    // Start is called before the first frame update
    void Start()
    {
        sliderPynya = GameObject.Find("EventSystem").GetComponent<SliderPynya>();
        changePerSecond = sliderPynya.changePersecondByBarHit;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        scale -= changePerSecond * Time.deltaTime;

        GameObjectFade.transform.localScale = new Vector3(scale, scale, 1);
    }

    void OnMouseDown()
    {
        CalScore();
        sliderPynya.spawnable = true;
        Destroy(gameObject);
    }

    void CalScore()
    {
        if (scale <= 3 && scale > 2)
            sliderPynya.badhit++;
        if (scale <= 2 && scale > 1.25)
            sliderPynya.goodhit++;
        if (scale <= 1.25 && scale > 0.75)
            sliderPynya.perfecthit++;
        if (scale <= 0.75&& scale>0.25)
            sliderPynya.goodhit++;
        if (scale<=0.25)
            sliderPynya.badhit++;

        Debug.Log("bad_" + sliderPynya.badhit +" good_"+ sliderPynya.goodhit+" perfect_"+ sliderPynya.perfecthit);
    }

}
