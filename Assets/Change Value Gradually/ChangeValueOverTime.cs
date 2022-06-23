using UnityEngine;
using UnityEngine.UI;

public class ChangeValueOverTime : MonoBehaviour
{

    public Text indicator;

    public bool useFixedUpdate;

    public float variableToChange;

    public float changePerSecond;

    void Update()
    {

        if (!useFixedUpdate)
        {
            variableToChange += changePerSecond * Time.deltaTime;
        }


        /*
        if (variableToChange - ((int)variableToChange) < 0.01f)
        {
            Debug.Break();
        }*/

        indicator.text = ((int)variableToChange).ToString();
    }

    void FixedUpdate()
    {

        if (useFixedUpdate)
        {
            variableToChange += changePerSecond * Time.deltaTime;
        }

    }

}
