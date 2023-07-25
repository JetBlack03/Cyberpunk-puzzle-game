using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public string ammoType;
    public int ammoVal;
    
    


    // Start is called before the first frame update
    void Start()
    {
        if(ammoType == "LA")
        {
            ammoVal = 910;
        }
        else if(ammoType == "MA")
        {
            ammoVal = 995;
        }
        else if(ammoType == "HA")
        {
            ammoVal = 991;
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }


}
