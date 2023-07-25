using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame : MonoBehaviour
{
    public GameObject barrier;
    public GameObject gate;
    public GameObject challenge;
    public AudioSource source;
    public int children;
    public bool two;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void BeginMinigame()
    {
        if (barrier.activeInHierarchy)
        {
            barrier.SetActive(false);
            Instantiate(challenge, transform);
            transform.GetChild(children).GetChild(0).GetComponent<GreenBall>().minigame = this;
            if (two) transform.GetChild(children).GetChild(6).GetComponent<GreenBall>().minigame = this;
        }
    }

    public void FailMinigame()
    {
        barrier.SetActive(true);
        Destroy(transform.GetChild(children).gameObject);
        
    }

    public void Succeed()
    {
        gate.SetActive(false);
        source.Play();
    }
}
