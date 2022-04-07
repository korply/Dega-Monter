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
        progressBar.SetMaxProgress(300);
        progressBar.SetProgress(0);

    }

    // Update is called once per frame
    void Update()
    {

        counterText.text = " Coin_" + Resource_Coin.totalCoins.ToString() ;

        float totaltime = Time.realtimeSinceStartup;
        progressBar.SetProgress(totaltime);
    }
}