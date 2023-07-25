using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DatapadScreen : MonoBehaviour
{

    GameObject player;
    public GameObject basicGUI;
    public GameObject datapad;
    GameObject cam;
    public bool datapadActive;
    public bool isUsing;
    GameObject Canvas;

    public string line1, line2;

         public DiologHit hit;

    private bool canType;
    private bool isDone;

    // Start is called before the first frame update
    void Start()
    {
        isUsing = false;
        canType = true;
        isDone = false;
        player = GameObject.FindGameObjectWithTag("Player");
        cam = GameObject.FindGameObjectWithTag("MainCamera");

        Canvas = transform.parent.gameObject;

    }

    // Update is called once per frame
    void Update()
    {



        if (Input.GetKeyDown(KeyCode.Escape) && datapadActive == true)
        {
            if(hit != null)
            {
                hit.numberOfHits--;
            }
            basicGUI.SetActive(true);
            datapadActive = false;
            isUsing = false;
            Invoke("pauseState", 0.001f);

            player.GetComponent<PlayerMove>().enabled = true;
            player.GetComponent<Shoot>().enabled = true;
            player.GetComponent<LaserShoot>().enabled = true;
            cam.GetComponent<MouseLook>().enabled = true;

        }

        if (datapadActive == true)
        {
            datapad.SetActive(true);
            datapad.transform.GetChild(1).GetComponent<Text>().text = line1;
            datapad.transform.GetChild(2).GetComponent<Text>().text = line2;
            basicGUI.SetActive(false);
            player.GetComponent<PlayerMove>().enabled = false;
            player.GetComponent<Shoot>().enabled = false;
            player.GetComponent<LaserShoot>().enabled = false;
            cam.GetComponent<MouseLook>().enabled = false;
            Canvas.GetComponent<PauseMenu>().canPause = false;

            
            isUsing = true;
        }
        else if (datapadActive == false)
        {
            datapad.SetActive(false);
            

            if (isUsing == false)
            {
                
                /*player.GetComponent<PlayerMove>().enabled = true;
                player.GetComponent<Shoot>().enabled = true;
                player.GetComponent<LaserShoot>().enabled = true;
                cam.GetComponent<MouseLook>().enabled = true;*/
                //isUsing = true;
            }

        }
    }

    public void pauseState()
    {
        Canvas.GetComponent<PauseMenu>().canPause = true;
    }

}
