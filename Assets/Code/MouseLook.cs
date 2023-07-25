using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MouseLook : MonoBehaviour
{
    //public float defultMouseSense;
    public float mouseSence = 100f;
    public Transform player;
    float xRotation;
    float timeStarted;
    public PasswordScreen pw;
    public TextMeshProUGUI text;
    public bool cutscene;

    // Start is called before the first frame update
    void Start()
    {
        
        //defultMouseSense = mouseSence;
    }

    // Update is called once per frame
    void Update()
    {

        if (!cutscene)
        {
            NormalFunction();
        }
    }

    public void NormalFunction()
    {
        Cursor.lockState = CursorLockMode.Locked;
        float mouseX = Input.GetAxis("Mouse X") * mouseSence * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSence * Time.deltaTime;

        player.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        if (!pw.isUsing)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                mouseSence = 50;
                text.text = "Low Mouse Sensitivity Selected";
                timeStarted = Time.time;

            }
            if (Input.GetKeyDown(KeyCode.U))
            {
                mouseSence = 100;
                text.text = "Medium Mouse Sensitivity Selected";
                timeStarted = Time.time;

            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                mouseSence = 150;
                text.text = "High Mouse Sensitivity Selected";
                timeStarted = Time.time;
            }
        }
        if (Time.time - timeStarted > 3)
        {
            text.text = "";
        }

    }
}
