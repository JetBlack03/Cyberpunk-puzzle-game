using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{

    public GameObject startUi;
    public GameObject howToPlayUi;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void play()
    {
        SceneManager.LoadScene( 1);
    }

    public void howToPlay()
    {
        startUi.SetActive(false);
        howToPlayUi.SetActive(true);
    }

    public void back()
    {
        startUi.SetActive(true);
        howToPlayUi.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }


}
