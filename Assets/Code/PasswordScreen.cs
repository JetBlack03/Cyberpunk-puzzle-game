using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswordScreen : MonoBehaviour
{
    public Text passwordText;
    public Text infoText;
    public string correctPassword;
    public GameObject password;
    public GameObject basicGUI;
    public bool passwordActive;
    public GameObject door;
    GameObject player;
    GameObject Canvas;
    public bool canType;
    public bool hasCalled;
    public bool hasEnded;
    public bool isUsing;

    public AudioSource success;
    public AudioSource failure;

    // Start is called before the first frame update
    void Start()
    {
        infoText.text = "Enter Password: ";
        passwordText.text = "";
        canType = true;
        hasCalled = false;
        hasEnded = false;
        isUsing = false;
        passwordActive = false;
        player = GameObject.FindGameObjectWithTag("Player");
        Canvas = transform.parent.gameObject;

    }

    // Update is called once per frame
    void Update()
    {

       

        if(Input.GetKeyDown(KeyCode.Escape) && passwordActive == true)
        {

            
            passwordActive = false;
            isUsing = false;
            basicGUI.SetActive(true);

            if (hasEnded == true)
            {
                //hasCalled = true;
                hasEnded = false;
                canType = true;
                passwordText.text = "";
                Invoke("PauseState", 0.1f);
            }
            else
            {
                passwordText.text = "";
                hasCalled = false;
                Invoke("PauseState", 0.1f);
            }

            

            player.GetComponent<PlayerMove>().enabled = true;
            player.GetComponent<Shoot>().enabled = true;
            player.GetComponent<LaserShoot>().enabled = true;


        }

        if(passwordActive == true)
        {
            password.SetActive(true);
            basicGUI.SetActive(false);
            player.GetComponent<PlayerMove>().enabled = false;
            player.GetComponent<Shoot>().enabled = false;
            player.GetComponent<LaserShoot>().enabled = false;
            isUsing = true;
            Canvas.GetComponent<PauseMenu>().canPause = false;

        }
        else if(passwordActive == false)
        {
            password.SetActive(false);
            

            if (isUsing == false)
            {
              
                /*player.GetComponent<PlayerMove>().enabled = true;
                player.GetComponent<Shoot>().enabled = true;
                player.GetComponent<LaserShoot>().enabled = true;*/
                
                //isUsing = true;
            }

        }

        

        if(passwordActive == true)
        {

            if (canType == true)
            {
                foreach (char c in Input.inputString)
                {

                    if (c == '\b') // has backspace/delete been pressed?
                    {
                        if (passwordText.text.Length != 0)
                        {
                            passwordText.text = passwordText.text.Substring(0, passwordText.text.Length - 1);
                        }
                    }
                    else if ((c == '\n') || (c == '\r')) // enter/return
                    {
                        if (passwordText.text == correctPassword)
                        {
                            passwordText.text = "ACCESS GRANTED";
                            Destroy(door);
                            canType = false;
                            hasEnded = true;
                            success.Play();
                        }
                        else
                        {
                            passwordText.text = "ACCESS DENIED";
                            canType = false;
                            failure.Play();
                            Invoke("Restart", 1);
                        }
                    }
                    else
                    {
                        passwordText.text += c;
                    }

                    if (hasCalled == false)
                    {
                        passwordText.text = "";
                        hasCalled = true;
                    }

                }
            }

        }
    }

    public void Restart()
    {
        passwordText.text = "";
        infoText.text = "Enter Password:";
        canType = true;
    }

    public void PauseState()
    {
        Canvas.GetComponent<PauseMenu>().canPause = true;
    }


}
