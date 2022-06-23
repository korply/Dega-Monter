using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetForSmith : MonoBehaviour
{
    public SliderPynya sliderPynya;

    // Start is called before the first frame update
    void Start()
    {
        sliderPynya = GameObject.Find("EventSystem").GetComponent<SliderPynya>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        sliderPynya.spawnable = true;
        Destroy(gameObject);
    }


}
