using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{

    public float spinSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Random.Range(180,360)* Time.deltaTime, Random.Range(180, 360) * Time.deltaTime, Random.Range(-180, -360)* Time.deltaTime);
    }
}
