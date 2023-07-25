using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TemperatureChange : MonoBehaviour
{

    public bool laserHit;
    float temperature;
    public float increaseRate;
    public float decreaseRate;
    public TextMeshProUGUI tempText;
    public TextMeshProUGUI rangeText;
    public float min, max;

    // Start is called before the first frame update
    void Start()
    {
        rangeText.text = "Range: \n" + min + "°C - " + max +"°C\n ";
    }

    // Update is called once per frame
    void Update()
    {
        if (!laserHit)
        {
            temperature -= decreaseRate * Time.deltaTime;
            if (temperature < 20) temperature = 20;
        }
        else
        {
            temperature += increaseRate * Time.deltaTime;
            laserHit = false;
            if (temperature > 100) temperature = 100;


        }

        tempText.text = (int)temperature + "°C";

    }

    public bool WithinRange()
    {
        if (temperature <= (max+0.99f) && temperature >= min)
            return true;
        else
            return false;
    }
}
