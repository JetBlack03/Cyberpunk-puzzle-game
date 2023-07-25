using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCondition : MonoBehaviour
{
    string[] dialogueLines;
    bool talkedTo;
    GameObject[] OffLamps;
    GameObject[] OnLamps;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        bool cleared = true;
        foreach(GameObject lamp in OffLamps)
        {
            if (lamp.activeInHierarchy)
                cleared = false;
        }
        foreach (GameObject lamp in OnLamps)
        {
            if (!lamp.activeInHierarchy)
                cleared = false;
        }
        if(cleared)
        {

        }
    }
}
