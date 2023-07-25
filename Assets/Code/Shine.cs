using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shine : MonoBehaviour
{
    Transform cam;
    public Transform camPos;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        camPos.position = cam.position;
        Vector3 newPos = camPos.localPosition;
        newPos.z = 0;
        camPos.localPosition = newPos ;
        Vector3 vec = camPos.localPosition - transform.localPosition;
      //  print("arcsin: " + Mathf.Asin(vec.y) + " arccos: " + Mathf.Acos(vec.x));

        float dir = Mathf.Rad2Deg*Mathf.Atan(vec.y/vec.x)  + 90;
        if (Mathf.Acos(vec.x) > Mathf.PI / 2)
        {
            dir += 180;
        }
        transform.LookAt(camPos);
        Vector3 newRot = transform.localEulerAngles;
        newRot.x = 0;
        newRot.z = newRot.y;
        newRot.y = -180;
        print("new rotation z: " + newRot.z);
        transform.localEulerAngles = newRot;

        Vector3 rot = transform.localEulerAngles;
        rot.z = dir;
      //  transform.localEulerAngles = rot;
    }
}
