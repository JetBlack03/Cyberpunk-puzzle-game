
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBall : MonoBehaviour
{
    public bool first;
    public Minigame minigame;

    public Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rbody = GetComponent<Rigidbody>();
        rbody.velocity = velocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Woo")
        {
            print("i");
            if(!first) minigame.Succeed();
            Destroy(gameObject);
        }
        else
        {
            minigame.FailMinigame();
        }
    }
}
