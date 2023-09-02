using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Datapad : MonoBehaviour
{
    DatapadScreen screen;
    public string line1, line2;
    public DiologHit hit;
    bool first;
    public int id;

    // Start is called before the first frame update
    void Start()
    {
        first = true;
        screen = GameObject.FindGameObjectWithTag("Game UI").GetComponent<DatapadScreen>();

    }


    public void OpenDatapad()
    {

        if(id < 12) 
            GameObject.Find("Level GUI").GetComponent<PauseMenu>().DatapadViewed(id, line1);
        screen.hit = null;
        if(hit != null && first)
        {
            screen.hit = hit;
            first = false;
            if (hit.numberOfHits == 1)
                GameObject.Find("Level GUI").GetComponent<PauseMenu>().map = true;
        }
        screen.datapadActive = true;
        screen.line1 = line1;
        screen.line2 = line2;
    }
}
