using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public bool paused;
    public GameObject pauseMenu;
    public GameObject player;
    public GameObject cam;
    public GameObject gameUI;
    public bool canPause;
    public Animator playerAnim;
    public Image knob;
    public GameObject mapMenu;
    public bool map;
    public string[] viewedPads;

    public AudioMixer mixer;
     
    public Transform inventory;
    public Transform inventorySelect;
    public Button[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        canPause = true;
        //player = GameObject.FindGameObjectWithTag("Player");
        //cam = GameObject.FindGameObjectWithTag("MainCamera");

    }

    // Update is called once per frame
    void Update()
    {
        if (!paused)
        {
            if(Input.GetKeyDown(KeyCode.P) && canPause || Input.GetKeyDown(KeyCode.Escape) && canPause || map && canPause && Input.GetKeyDown(KeyCode.M))
            {
                
                paused = true;
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
                if(map && canPause && Input.GetKeyDown(KeyCode.M))
                {
                    Map();
                }
                else
                {
                    transform.GetChild(4).GetChild(0).gameObject.SetActive(true);
                    transform.GetChild(4).GetChild(1).gameObject.SetActive(true);


                    if (mapMenu != null)
                    {
                        mapMenu.SetActive(false);
                        if (map)
                            transform.GetChild(4).GetChild(1).GetChild(7).gameObject.SetActive(true);
                        else
                            transform.GetChild(4).GetChild(1).GetChild(7).gameObject.SetActive(false);
                    }
                }
            }

            player.GetComponent<PlayerMove>().enabled = true;
            player.GetComponent<Shoot>().enabled = true;
            player.GetComponent<LaserShoot>().enabled = true;
            cam.GetComponent<MouseLook>().enabled = true;
            gameUI.SetActive(true);

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
            {
                Resume();
            }

            player.GetComponent<PlayerMove>().enabled = false;
            player.GetComponent<Shoot>().enabled = false;
            player.GetComponent<LaserShoot>().enabled = false;
            cam.GetComponent<MouseLook>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            gameUI.SetActive(false);


        }

        

        Vector3 pos = player.transform.position;
       if(knob!=null)
            knob.rectTransform.localPosition = new Vector3(3.73923411f * pos.x - 293.160203f, 3.97694995f * pos.z + 12.807579f, 0);
    }

    public void Resume()
    {
        paused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        inventory.gameObject.SetActive(false);
        inventorySelect.gameObject.SetActive(false);
        if (mapMenu!=null && mapMenu.activeInHierarchy)
        {
            transform.GetChild(4).GetChild(0).gameObject.SetActive(true);
            transform.GetChild(4).GetChild(1).gameObject.SetActive(true);
            mapMenu.SetActive(false);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void PlayerStand()
    {
        print("stnad");
        playerAnim.Play("wake up");
    }

    public void Map()
    {
        mapMenu.SetActive(true);
        transform.GetChild(4).GetChild(0).gameObject.SetActive(false);
        transform.GetChild(4).GetChild(1).gameObject.SetActive(false);
    }

    public void VolumeChange(Slider v)
    {
        mixer.SetFloat("MusicVol", 20 + Mathf.Log10(v.value ) * 20);
    }



    public void DatapadsSelection()
    {
        for (int i = 0; i < 4; i++)
        {
            if (viewedPads[i].Length == 0)
            {
                buttons[i].interactable = false;
                inventorySelect.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(.4f, .4f, .4f);
            }
            else
            {
                buttons[i].interactable = true;
                inventorySelect.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1);
            }
        }

    }

    public void Datapad(int datapad)
    {
        inventory.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Datapad 0" + (datapad+1);
        inventory.GetChild(2).GetChild(1).GetComponent<Text>().text = viewedPads[datapad];
        for (int i = 0; i < 4; i++)
        {
            if (i == datapad)
                inventory.GetChild(6).GetChild(i).gameObject.SetActive(true);
            else
                inventory.GetChild(6).GetChild(i).gameObject.SetActive(false);
        }
    }

    public void NextLevel()
    {

    }
}
