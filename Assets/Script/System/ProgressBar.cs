using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{

    public Slider slider;

    public void SetMaxProgress(float progress)
    {
        slider.value = progress;
        slider.maxValue = progress;
    }
   public void SetProgress(float progress)
    {
        
        slider.value = progress;
    }
}
