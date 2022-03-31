using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resource_counter : MonoBehaviour
{
    Text counterText;
    public ProgressBar progressBar;

    // Start is called before the first frame update
    void Start()
    {
        counterText = GetComponent<Text>();
        progressBar.SetMaxProgress(100);
        progressBar.SetProgress(0);

    }

    // Update is called once per frame
    void Update()
    {

        counterText.text = " Herb_" + Resource_Herb.totalHerbs.ToString() +
                           " Orb_" + Resource_Orb.totalOrbs.ToString() +
                           " Rock_" + Resource_Rock.totalRocks.ToString() +
                           " Steel_" + Resource_Steel.totalSteels.ToString() +
                           " Water_" + Resource_Water.totalWaters.ToString() +
                           " Wood_" + Resource_Wood.totalWoods.ToString();

        int totalgain = Resource_Herb.totalHerbs + Resource_Orb.totalOrbs + Resource_Rock.totalRocks + Resource_Steel.totalSteels + Resource_Water.totalWaters + Resource_Wood.totalWoods;
        progressBar.SetProgress(totalgain);
    }
}