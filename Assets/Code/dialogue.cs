using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialogue : MonoBehaviour
{

    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public int index;
    public float typingSpeed;

    public GameObject continueButton;
    public GameObject diologBox;

    private bool early;

    public GameObject player;

    private bool hasReset;
    public bool isDone;

    public bool openEyes;
    public Animator anim;

    void Start()
    {
        StartCoroutine(Type());
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.F) && continueButton.activeInHierarchy && textDisplay.text == sentences[index])
        {
            NextSentence();
        }else if (Input.GetKeyDown(KeyCode.F))
        {
            textDisplay.text = sentences[index];
            early = true;
        }
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }


        if (diologBox.active == false && hasReset == true)
        {
            textDisplay.text = "";
            print("lets gooooo");
            early = false;

            diologBox.SetActive(true);
            player.GetComponent<ItemPickup>().enabled = false;
            player.GetComponent<PlayerMove>().moving = 0;

            StartCoroutine(Type());
            hasReset = false;
        }

    }

    //WaitForSeconds(typingSpeed);
    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {

            if (early)
            {
                early = false;
                yield break;
            }
            
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);

            


        }

    }

    public void NextSentence()
    {
        continueButton.SetActive(false);

        

        if (index < sentences.Length - 1)
        {

            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
            diologBox.SetActive(true);
        }
        else
        {
            player.GetComponent<ItemPickup>().enabled = true;
            player.GetComponent<PlayerMove>().moving = 1;

            textDisplay.text = "";
            continueButton.SetActive(false);
            diologBox.SetActive(false);
            isDone = true;
            if (openEyes)
            {
                anim.SetBool("Started", true);
                player.GetComponent<PlayerMove>().WakeUp();
                openEyes = false;
                //  playerAnim.Play("wake up");
                player.GetComponent<PlayerMove>().moving = 0;
            }
        }
    }

    public void ResetD()
    {
        index = 0;
        hasReset = true;
        isDone = false;
    }

}


