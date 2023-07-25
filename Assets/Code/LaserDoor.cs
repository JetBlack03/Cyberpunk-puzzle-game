using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDoor : MonoBehaviour
{

    public GameObject laserHitPoint1;
    public GameObject laserHitPoint2;
    public GameObject laserHitPoint3;
    public GameObject laserHitPoint4;
    public bool x = false;
    public bool y = false;
    public bool z = false;
    public float hitForce;
    public bool hasCalled;
    public GameObject killObject;


    // Start is called before the first frame update
    void Start()
    {
        hasCalled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
       if(CheckLaserHit() && hasCalled == false)
       {
            transform.gameObject.AddComponent(typeof(Rigidbody));
            if (killObject != null) Destroy(killObject);

            if (x == true)
            {
                transform.gameObject.GetComponent<Rigidbody>().AddForce(-1 * hitForce,0,0);
            }
            else if(y == true)
            {
                transform.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * -1 * hitForce);
            }
            else if (z == true)
            {
                transform.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * -1 * hitForce);
            }
            hasCalled = true;
       }

    }

    private bool CheckLaserHit()
    {

        if(laserHitPoint1.GetComponent<LaserHit>().laserHit && laserHitPoint2.GetComponent<LaserHit>().laserHit && laserHitPoint3.GetComponent<LaserHit>().laserHit && laserHitPoint4.GetComponent<LaserHit>().laserHit)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

}
