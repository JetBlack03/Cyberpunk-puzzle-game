using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameTarget : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnCollisionEnter(Collision collision)
    {
        print("tag " + collision.gameObject.tag);
        if (collision.gameObject.name == "green")
        {
            transform.parent.GetChild(1).gameObject.SetActive(false);
            transform.parent.GetChild(2).gameObject.SetActive(true);
        }
    }
}
