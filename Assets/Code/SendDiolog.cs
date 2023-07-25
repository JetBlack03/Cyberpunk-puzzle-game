using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendDiolog : MonoBehaviour
{

    public GameObject DC;
    public GameObject many;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Dialogue" && DC.GetComponent<dialogue>().isDone == true)
        {
            Send(other.GetComponent<DiologHit>().sentences);

            if (other.GetComponent<DiologHit>().hasNext)
            {
                other.GetComponent<DiologHit>().next.SetActive(true);
            }
            Destroy(other.gameObject, 0.1f);

        }
    }

    public void Send(string[] sentences)
    {
        DC.GetComponent<dialogue>().sentences = sentences;
        DC.GetComponent<dialogue>().ResetD();


        if (many != null)
        {
            many.GetComponent<DiologHit>().Hit++;
        }

    }

}
