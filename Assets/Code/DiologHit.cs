using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiologHit : MonoBehaviour
{

    public string[] sentences;

    public bool hasNext;
    public bool hasMany;

    public int numberOfHits;
    public int Hit;

    public GameObject next;

    // Start is called before the first frame update
    void Start()
    {
        if(next!=null)next.SetActive(false);

        if(hasMany == true)
        {
            transform.gameObject.GetComponent<BoxCollider>().enabled = false;
        }

        
        
    }

    // Update is called once per frame
    void Update()
    {
        Hit = 0;
        if (numberOfHits <= Hit && hasMany == true)
        {
            transform.gameObject.GetComponent<BoxCollider>().enabled = true;
            hasMany = false;
        }

    }



}
