using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneItemReciever : MonoBehaviour
{
    public string[] dialogueLines;
    public string[] failureDialogue;
    GameObject player;
    public GameObject desiredObject;
    public GameObject[] undesiredObjects;
    public bool recieved;
    public DiologHit hit;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendDialogue()
    {
        if (player.GetComponent<Inventory>().pickup != null && player.GetComponent<Inventory>().pickup.Equals(desiredObject))
        {
            if (hit != null)
                hit.numberOfHits--;
            player.GetComponent<SendDiolog>().Send(dialogueLines);
            player.GetComponent<Inventory>().RemoveObject();
            Destroy(desiredObject);
            recieved = true;
        }
        else if (recieved)
        {
            player.GetComponent<SendDiolog>().Send(dialogueLines);

        }
        else
        {
            print(player.GetComponent<Inventory>().pickup);
            print(desiredObject);
            bool fail = false;
            foreach(GameObject pickup in undesiredObjects)
            {
                if(pickup.Equals (player.GetComponent<Inventory>().pickup))
                {
                    fail = true;
                    print("aa");
                }
            }
            if (fail)
                player.GetComponent<SendDiolog>().Send(failureDialogue);
            else
                GetComponent<Drone>().StartDialogue(true);
        }

    }
}
