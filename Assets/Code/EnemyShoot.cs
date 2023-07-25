using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    public Transform player;

    private Vector3 destination;
    public Transform firePoint;
    public GameObject projectile;
    private float timeToFire;


    public void ShootProjectile()
    {
        Debug.Log("EnemyShoot");

        Ray aimRay = new Ray(firePoint.position, player.position - firePoint.position);
        RaycastHit hit;

        Debug.DrawRay(transform.position, player.position - firePoint.position);

        if (Physics.Raycast(aimRay, out hit))
        {
            Debug.Log("EnemyGetDestinition");
            destination = hit.point;
        }

        if(Time.time >= timeToFire && projectile != null)
        {
            timeToFire = Time.time + 1 / projectile.GetComponent<EnemyProjectile>().fireRate;
            Debug.Log("EnemyShooting");
            CreateProjectile(firePoint);
        }
        
    }

    void CreateProjectile(Transform firePoint)
    {

        var projectileObj = Instantiate(projectile, firePoint.position, Quaternion.LookRotation(destination - firePoint.position).normalized) as GameObject;
        float projectileSpeed = projectileObj.GetComponent<EnemyProjectile>().projectileSpeed;
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * projectileSpeed;

    }

}
