using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Password : MonoBehaviour
{
    public string correctPassword;
    public PasswordScreen screen;
    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        screen = GameObject.FindGameObjectWithTag("Game UI").GetComponent<PasswordScreen>();
    }


    public void OpenPassword()
    {
        screen.passwordActive = true;
        screen.correctPassword = correctPassword;
        screen.door = door;
    }
    
}
