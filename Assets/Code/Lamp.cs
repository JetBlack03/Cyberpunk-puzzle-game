using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    public int power = 1;
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

        if (collision.gameObject.tag == "Bullet")
        {

            if (collision.transform.GetComponent<Projectile>().ammoType == "MA")
            {
                power *= -1;

                if(power == 1)
                {
                    transform.GetChild(1).gameObject.SetActive(true);
                    transform.GetChild(4).gameObject.SetActive(false);

                }
                else if (power == -1)
                {
                    transform.GetChild(1).gameObject.SetActive(false);
                    transform.GetChild(4).gameObject.SetActive(true);

                }

            }
        }

    }


}
