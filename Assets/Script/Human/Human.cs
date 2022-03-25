using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Human
{
    public string NameType;
    public int HP;
    public Slider slider;
  
    public Human(string nameType, int hp)
    {
        NameType = nameType;
        HP = hp;
        
    }
    public void SetMaxHealth(int agihealth)
    {
        slider.maxValue = agihealth;
        slider.value = agihealth;
    }
    public void Sethealth(int agihealth)
    {
        slider.value = agihealth;
    }
}
