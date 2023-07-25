using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadScreen : MonoBehaviour
{
    public string correctPass;
    private string inputPass;
    public Text outputText;
    GameObject player;
    public GameObject basicGUI;
    public GameObject keypad;
    GameObject cam;
    public bool keypadActive;
    public bool isUsingKeypad;
    public int passLength;
    public GameObject door;
    private bool canType;
    public bool isDone;
    GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        isUsingKeypad = false;
        canType = true;
        isDone = false;
        player = GameObject.FindGameObjectWithTag("Player");
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        canvas = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        outputText.text = inputPass;

        if (Input.GetKeyDown(KeyCode.Escape) && keypadActive == true)
        {
            KeypadDeactivated();
            

        }

        if (keypadActive == true)
        {
            KeypadActivated();
        }
        else if (keypadActive == false)
        {

            keypad.SetActive(false);
            

            if(isUsingKeypad == false)
            {
                
                /*player.GetComponent<PlayerMove>().enabled = true;
                player.GetComponent<Shoot>().enabled = true;
                player.GetComponent<LaserShoot>().enabled = true;
                cam.GetComponent<MouseLook>().enabled = true;*/
                //isUsing = true;
            }

            
        }

        /*if(inputPass.Length >= passLenth + 1)
        {
            inputPass = inputPass.Substring(0, inputPass.Length - 1);
        }*/

    }
    

    public void EnterNumber(int number)
    {
        if (canType == true)
        {
            inputPass += number.ToString();
        }
    }

    public void EnterClear()
    {
       
        if(isDone == false)
        {
            canType = true;
        }   

        if (canType == true)
        {
            inputPass = "";
        }

    }
    
    public void KeypadActivated()
    {

        keypad.SetActive(true);
        basicGUI.SetActive(false);
        keypadActive = true;
        player.GetComponent<PlayerMove>().enabled = false;
        player.GetComponent<Shoot>().enabled = false;
        player.GetComponent<LaserShoot>().enabled = false;
        cam.GetComponent<MouseLook>().enabled = false;
        canvas.GetComponent<PauseMenu>().canPause = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        isUsingKeypad = true;
    }

    public void KeypadDeactivated()
    {
        print("woo");
        keypadActive = false;
        isUsingKeypad = false;
        basicGUI.SetActive(true);
        Invoke("pauseState", 0.001f);

        player.GetComponent<PlayerMove>().enabled = true;
        player.GetComponent<Shoot>().enabled = true;
        player.GetComponent<LaserShoot>().enabled = true;
        cam.GetComponent<MouseLook>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void EnterEnter()
    {
        if(inputPass == correctPass)
        {
            inputPass = "ACCESS GRANTED";
            canType = false;
            isDone = true;
            Destroy(door);
        }
        else
        {
            inputPass = "ACCESS DENIED";
            Invoke("EnterClear", 1);
        }
    }

    public void pauseState()
    {
        canvas.GetComponent<PauseMenu>().canPause = true;
    }





}
