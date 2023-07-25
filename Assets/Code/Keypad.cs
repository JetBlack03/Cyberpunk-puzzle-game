using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    public string correctPass;
    KeypadScreen keypadScreen;
    public int passLength;
    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        keypadScreen = GameObject.FindGameObjectWithTag("Game UI").GetComponent<KeypadScreen>();

    }

    // Update is called once per frame




    public void UseKeypad()
    {
        keypadScreen.correctPass = correctPass;
        keypadScreen.passLength = passLength;
        keypadScreen.door = door;
        keypadScreen.KeypadActivated();
    }
    



}
