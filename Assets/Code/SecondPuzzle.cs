using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPuzzle : MonoBehaviour
{
    public DiologHit dhit;
    public DiologHit dhit2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dhit.numberOfHits < 2)
        {
            dhit.gameObject.GetComponent<BoxCollider>().enabled = true;
            if(dhit.numberOfHits < 1 )
            {
                if(dhit2.numberOfHits > 0)
                {
                    dhit.sentences[0] = "AI: I think the two datapads you’ve found will help you solve the password," +
                        " but you might need to find one more. Look around the area and see if you can find anything.";
                }
                else
                {
                    Destroy(dhit.gameObject);
                }
            }
        }
    }
}
