using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    float startY;
    public float hoverStrength = 0.1f;
    Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        startY = position.y;    
    }

    // Update is called once per frame
    void Update()
    {
        position.y = startY + hoverStrength * Mathf.Sin(Time.time * 3);
        transform.position = position;
    }
}
