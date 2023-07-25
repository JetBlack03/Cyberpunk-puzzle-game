using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public Camera fpsCam;

    private Vector3 destination;
    public Transform firePoint;
    public GameObject projectile;
    public Animator armAniCon;

    public int lightAmmo;
    public int mediumAmmo;
    public int heavyAmmo;

    private float timeToFire;

    public AudioSource plasmaSound;
    public AudioSource electricitySound;
    public AudioSource laserSound;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(Input.GetButton("Fire1"))
        {
            armAniCon.SetBool("isShoot", true);
           
        }
        else
        {
            armAniCon.SetBool("isShoot", false);
            
        }
        

        if(WeaponSwitch.instance.activeWeapon != null && WeaponSwitch.instance.activeWeapon.isLaser == false)
        {
            projectile = WeaponSwitch.instance.activeWeapon.projectile;
        }
        else if(WeaponSwitch.instance!= null && WeaponSwitch.instance.activeWeapon!= null && WeaponSwitch.instance.activeWeapon.isLaser == true)
        {
            projectile = null;
        }

        if(projectile!=null&& projectile.transform.GetComponent<Projectile>() != null)
        {
            if (Input.GetButton("Fire1") && Time.time >= timeToFire && projectile != null)
            {

                timeToFire = Time.time + 1 / projectile.GetComponent<Projectile>().fireRate;

                if (lightAmmo > 0 && projectile.GetComponent<Projectile>().ammoType == "LA")
                {
                    lightAmmo -= 1;
                    ShootProjectile();
                    plasmaSound.Play();
                }
                else if (mediumAmmo > 0 && projectile.GetComponent<Projectile>().ammoType == "MA")
                {
                    mediumAmmo -= 1;
                    ShootProjectile();
                    electricitySound.Play();
                }
                else if (heavyAmmo > 0 && projectile.GetComponent<Projectile>().ammoType == "HA")
                {
                    heavyAmmo -= 1;
                    ShootProjectile();
                    //laserSound.Play();
                }

            }
        }




    }

    private void OnTriggerEnter(Collider other)
    {



        if(other.tag == "Ammo")
        {


            if (other.GetComponent<Ammo>().ammoType == "LA")
            {
                lightAmmo += other.GetComponent<Ammo>().ammoVal;
            }
            else if(other.GetComponent<Ammo>().ammoType == "MA")
            {
                mediumAmmo += other.GetComponent<Ammo>().ammoVal;
            }
            else if(other.GetComponent<Ammo>().ammoType == "HA")
            {
                heavyAmmo += other.GetComponent<Ammo>().ammoVal;
            }

            other.GetComponent<Ammo>().Destroy();

        }
    }

    void ShootProjectile()
    {
        Ray aimRay = new Ray(fpsCam.transform.position, fpsCam.transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(aimRay, out hit))
        {
            destination = hit.point;
        }
        else
        {
            destination = aimRay.GetPoint(1000);
        }

        CreateProjectile(firePoint);

    }



    void CreateProjectile(Transform firePoint)
    {

        var projectileObj = Instantiate(projectile, firePoint.position, Quaternion.LookRotation(destination - firePoint.position).normalized) as GameObject;
        float projectileSpeed = projectileObj.GetComponent<Projectile>().projectileSpeed;
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * projectileSpeed;

    }
}
