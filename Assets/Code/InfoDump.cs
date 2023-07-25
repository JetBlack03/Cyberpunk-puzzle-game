using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InfoDump: MonoBehaviour
{

    public GameObject player;
    public GameObject basicGUI;
    public GameObject datapad;
    public GameObject cam;
    public bool isActive;
    public bool isUsing;
    public GameObject Canvas;
    public GameObject door;
    public GameObject words;

    private bool canType;
    private bool isDone;

    // Start is called before the first frame update
    void Start()
    {
        isUsing = false;
        canType = true;
        isDone = false;
    }

    // Update is called once per frame
    void Update()
    {



        if (Input.GetKeyDown(KeyCode.Escape) && isActive == true)
        {
            basicGUI.SetActive(true);
            isActive = false;
            isUsing = false;
            Invoke("pauseState", 0.001f);

            player.GetComponent<PlayerMove>().enabled = true;
            player.GetComponent<Shoot>().enabled = true;
            player.GetComponent<LaserShoot>().enabled = true;
            cam.GetComponent<MouseLook>().enabled = true;

            if (door != null)
            {
                Destroy(door);
                words.SetActive(true);
            }

        }

        if (isActive == true)
        {
            print("yeehaw");
            datapad.SetActive(true);
            print(datapad.activeInHierarchy);
            basicGUI.SetActive(false);
            player.GetComponent<PlayerMove>().enabled = false;
            player.GetComponent<Shoot>().enabled = false;
            player.GetComponent<LaserShoot>().enabled = false;
            cam.GetComponent<MouseLook>().enabled = false;
            Canvas.GetComponent<PauseMenu>().canPause = false;

            isUsing = true;
        }
        else if (isActive == false)
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
