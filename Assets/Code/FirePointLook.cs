using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePointLook : MonoBehaviour
{

    private Vector3 destination;
    public Camera fpsCam;

    // Start is called before the first frame update
    void Start()
    {

       

    }

    // Update is called once per frame
    void Update()
    {

        Ray aimRay = new Ray(fpsCam.transform.position, fpsCam.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(aimRay, out hit))
        {
            destination = hit.point;
        }
        else
        {
            destination = aimRay.GetPoint(1000);
        }

        transform.rotation = Quaternion.LookRotation(destination - transform.position).normalized;

    }
}
