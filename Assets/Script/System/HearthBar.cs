using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HearthBar : MonoBehaviour
{
    public Slider slider;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void Sethealth(int health)
    {
        slider.value = health;
    }
}
