using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public GameObject restartLevel;
    Camera cam;
    GameObject player;
    public Vector3 respawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player");
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
      /*  if(Input.GetKeyDown(KeyCode.Tab) )
        {
            Cursor.lockState = CursorLockMode.None;
            restartLevel.SetActive(true);
            cam.GetComponent<MouseLook>().enabled = false;
            player.GetComponent<PlayerMove>().enabled = false;
            player.GetComponent<Shoot>().enabled = false;
            player.GetComponent<LaserShoot>().enabled = false;

        }*/

    }

    void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "Respawn")
        {
            gameObject.layer = 1;
            print(respawnPoint);
            GetComponent<CharacterController>().Move(respawnPoint - transform.position);
           // transform.position = respawnPoint;
            print(transform.position);
            gameObject.layer = 11;

        }
        if(other.gameObject.tag == "RespawnLocation")
        {
            respawnPoint = other.transform.position;
        }
    }

    public void CloseMenu()
    {
        print("wtf");
        cam.GetComponent<MouseLook>().enabled = true;
        Cursor.lockState = CursorLockMode.None;
        player.GetComponent<PlayerMove>().enabled = true;
        player.GetComponent<Shoot>().enabled = true;
        player.GetComponent<LaserShoot>().enabled = true;

    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
