using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int enemyHealth = 100;
    public bool destroyL, destroyM, destroyH;

    public bool hasNext;
    public GameObject next;

    public bool killParent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(enemyHealth <= 0)
        {
            if (hasNext && next != null)
                next.SetActive(true);
            if (killParent)
                Destroy(transform.parent.gameObject);
            else
                Destroy(gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Bullet")
        {
            if(collision.transform.GetComponent<Projectile>().ammoType == "LA" && destroyL == true)
            {
                enemyHealth -= collision.transform.GetComponent<Projectile>().damageDealt;
            }

            if(collision.transform.GetComponent<Projectile>().ammoType == "MA" && destroyM == true)
            {
                enemyHealth -= collision.transform.GetComponent<Projectile>().damageDealt;
            }
            
            if(collision.transform.GetComponent<Projectile>().ammoType == "HA" && destroyH == true)
            {
                enemyHealth -= collision.transform.GetComponent<Projectile>().damageDealt;
            }

        }

    }

}
