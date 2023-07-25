using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemperatureSystemTimed : MonoBehaviour
{

    public float time;
    public TemperatureChange[] things;
    public GameObject gate;
    bool set;
    float timeStarted;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool working = true;
        foreach(TemperatureChange tempChange in things)
        {
            if (!tempChange.WithinRange())
            {
                working = false;
            }
        }

        if (working)
        {
            if (set)
            {
                if (Time.fixedUnscaledTime - timeStarted >= time)
                {
                    Destroy(gate);
                    text.text = "";

                }
                else
                {
                    text.text = (time - (Time.fixedUnscaledTime - timeStarted)).ToString("0.00") + "s";
                }
            }
            else
            {
                timeStarted = Time.fixedUnscaledTime;
                set = true;
                print("Let it begin");
            }
        }
        else
        {
            if (set)
            {
                text.text = "";
            }
            set = false;

        }
    }
}
