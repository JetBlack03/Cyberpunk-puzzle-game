using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    public bool lookAtPlayer;
    GameObject player;
    public string[] dialogueLines;
    public string[] secondaryDialogue;

    public bool secondary;

    public bool itemReciever;
    public bool lightCondition;

    public bool needsLaser;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (lookAtPlayer)
        {
            transform.LookAt(player.transform.GetChild(2), Vector3.up);
            //transform.rotation = Mathf.LerpAngle()
        }
    }

    
    public void StartDialogue(bool forceNormal)
    {
        Inventory inventory = player.GetComponent<Inventory>();
        if (itemReciever && !forceNormal && secondary )
        {
                GetComponent<DroneItemReciever>().SendDialogue();
        }else if(lightCondition && !forceNormal)
        {
            GetComponent<LightCondition>();
        }
        else
        {
            if (secondary)
            {
                player.GetComponent<SendDiolog>().Send(secondaryDialogue);

            }
            else
            {
                if (needsLaser && player.GetComponent<Inventory>().items.Count ==3)
                {
                    player.GetComponent<SendDiolog>().Send(secondaryDialogue);
                    if (secondaryDialogue.Length > 0) secondary = true;

                }
                else
                {
                    player.GetComponent<SendDiolog>().Send(dialogueLines);
                    if(!needsLaser && secondaryDialogue.Length > 0) secondary = true;
                }
                
            }
        }
        
    }


}
