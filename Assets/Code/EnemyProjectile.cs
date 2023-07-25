using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public GameObject hitPartical;
    public float projectileSpeed;
    public float impactForce;
    public float fireRate;
    public int damageDealt;

    bool collied;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "EnemyBullet" && collision.gameObject.tag != "Enemy" && !collied)
        {
            collied = true;

            if (collision.transform.GetComponent<Rigidbody>() != null)
            {
                Instantiate(hitPartical, collision.GetContact(0).point, Quaternion.LookRotation(collision.GetContact(0).normal));
                collision.transform.GetComponent<Rigidbody>().AddForce(-collision.GetContact(0).normal * impactForce);
            }
            else
            {
                Instantiate(hitPartical, collision.GetContact(0).point, Quaternion.LookRotation(collision.GetContact(0).normal));
            }

            Destroy(gameObject);
        }
    }

}
