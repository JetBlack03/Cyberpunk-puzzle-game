using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Basic Vars
    public CharacterController playerCon;
    public float movementSpeed;
    public float defualtMoveSpeed = 5;
    public float sprintspeed;
    public float gravity = -9.8f;
    public float jumpHight;
    
    // Ground Check Vars
    bool isGrounded;
    public LayerMask groundMask;
    public Transform groundCheck;
    public float groundCheckSize = .4f;

    public bool onPlatform;
    Vector3 velocity;
    Vector3 move;
    public int moving = 1;

    public Animator anim;
    bool startWakingUp;
    public Camera altCamera;
    public MouseLook mouselook;
    float startTime;
    bool transition;

    public string[] starterSentences;


    private void Start()
    {
        //defualtMoveSpeed = movementSpeed;
    }

    public void WakeUp()
    {
        anim.Play("wake up 0");
        altCamera.targetDisplay = 0;
        Camera.main.targetDisplay = 2;
        mouselook.cutscene = true;
        startWakingUp = true;
        Camera.main.transform.localRotation = Quaternion.identity;

        startTime = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        CheckGround();
        Move();
        Jump();

        if(startWakingUp && Time.time - startTime > 11.6f)
        {
            


            startWakingUp = false;

            transition = true;
            startTime = Time.time;

            anim.speed = 0;
            altCamera.nearClipPlane = 0.3f;
        }
        if (transition)
        {
            if (Time.time - startTime < 1.005f)
            {
                altCamera.transform.position = Vector3.Lerp(altCamera.transform.position, Camera.main.transform.position, .4f*(Time.time - startTime));
                altCamera.transform.rotation = Quaternion.Lerp(altCamera.transform.rotation, Camera.main.transform.rotation, .4f*(Time.time - startTime));
            }
            else
            {
                transition = false;
                altCamera.targetDisplay = 2;
                Camera.main.targetDisplay = 0;
                mouselook.cutscene = false;
                GetComponent<SendDiolog>().Send(starterSentences);
                anim.speed = 1;

            }
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHight * -2 * gravity) * moving;

        }
    }
    
    void CheckGround()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckSize, groundMask);
    }

    void Move()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2;
        }

        if (isGrounded)
        {
            move = transform.right * x + transform.forward * z;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerCon.Move(move * sprintspeed * moving * Time.deltaTime);
        }
        else
        {
            playerCon.Move(move * movementSpeed * moving * Time.deltaTime);
        }


        velocity.y += gravity * Time.deltaTime ;
        playerCon.Move(velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Platform")
        {
            onPlatform = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Platform")
        {
            onPlatform = false;
        }
    }
}
