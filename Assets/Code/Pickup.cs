using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickedUp()
    {
        transform.position = new Vector3(-200, 0, 0);
        player.GetComponent<Inventory>().PickUpObject(gameObject);
    }

    public void Drop()
    {
        print("drop");
        transform.position = player.position;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
