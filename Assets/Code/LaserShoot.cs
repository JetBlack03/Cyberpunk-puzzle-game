using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShoot : MonoBehaviour
{

    public GameObject laserPrefab;
    public GameObject firePoint;
    public float ammoUseRate;
    private float timeToFire; 
    public int laserDmg;
    public GameObject hitPartical;
    //public float mouseSlowSpeed;
    public GameObject playerCam;
    public float hitForce;
    public GameObject hitSmall;

    private GameObject spawedLaser;
    private GameObject spawnedHit;

    public AudioSource laserSound;

    // Start is called before the first frame update
    void Start()
    {

        spawedLaser = Instantiate(laserPrefab);
        DisableLaser();
        spawnedHit = Instantiate(hitPartical);
        DisableHit();

    }

    // Update is called once per frame
    void Update()
    {

        Ray aimRay = new Ray(firePoint.transform.position, firePoint.transform.forward);
        RaycastHit hit;


        if (Input.GetMouseButtonDown(0) && WeaponSwitch.instance.activeWeapon != null && WeaponSwitch.instance.activeWeapon.isLaser == true && transform.GetComponent<Shoot>().heavyAmmo > 0)
        {

            EnableLaser();
            if(Physics.Raycast(aimRay, out hit))
            {
                EnableHit();
            }

        }
        if(Input.GetMouseButton(0) && WeaponSwitch.instance.activeWeapon!=null && WeaponSwitch.instance.activeWeapon.isLaser == true && transform.GetComponent<Shoot>().heavyAmmo > 0)
        {
            UpdateLaser();
            if(!laserSound.isPlaying)
               laserSound.Play();
            
            if(Physics.Raycast(aimRay, out hit))
            {
                //playerCam.GetComponent<MouseLook>().mouseSence = mouseSlowSpeed; 
                UpdateHit(hit);

                if(hit.transform.gameObject.GetComponent<Rigidbody>() != null && hit.transform.gameObject.name != "green")
                {
                    hit.transform.gameObject.GetComponent<Rigidbody>().AddForce(hit.normal * -1 * hitForce);
                }

                Instantiate(hitSmall, hit.point, Quaternion.LookRotation(hit.normal));

            }
            else
            {
                //playerCam.GetComponent<MouseLook>().mouseSence = playerCam.GetComponent<MouseLook>().defultMouseSense;
            }
          

            if(Time.time >= timeToFire)
            {
                timeToFire = Time.time + 1 / ammoUseRate;
                transform.GetComponent<Shoot>().heavyAmmo -= 1;

                if (Physics.Raycast(aimRay, out hit))
                {
                    if(hit.transform.GetComponent<EnemyHealth>() && hit.transform.GetComponent<EnemyHealth>().destroyH == true)
                    {
                        hit.transform.GetComponent<EnemyHealth>().enemyHealth -= laserDmg;
                    }

                    if(hit.transform.GetComponent<LaserHit>())
                    {
                        hit.transform.GetComponent<LaserHit>().laserHit = true;
                    }

                    if(hit.transform.GetComponent<TemperatureChange>() != null)
                    {
                        hit.transform.GetComponent<TemperatureChange>().laserHit = true;
                    }

                }

            }

            if(transform.GetComponent<Shoot>().heavyAmmo <= 0)
            {
                DisableLaser();
                DisableHit();
                //playerCam.GetComponent<MouseLook>().mouseSence = playerCam.GetComponent<MouseLook>().defultMouseSense;
            }

        }
        if(Input.GetMouseButtonUp(0) && WeaponSwitch.instance.activeWeapon != null && WeaponSwitch.instance.activeWeapon.isLaser == true)
        {
            DisableLaser();
            DisableHit();
            laserSound.Stop();
            //playerCam.GetComponent<MouseLook>().mouseSence = playerCam.GetComponent<MouseLook>().defultMouseSense;
        }


    }

    void DisableLaser()
    {
        spawedLaser.SetActive(false);
    }

    void DisableHit()
    {
        spawnedHit.SetActive(false);
    }

    void EnableLaser()
    {
        spawedLaser.SetActive(true);
    }

    void EnableHit()
    {
        spawnedHit.SetActive(true);
    }

    void UpdateLaser()
    {
        if(firePoint != null)
        {
            /*
            spawedLaser.transform.parent = firePoint.transform;
            spawedLaser.transform.localPosition = Vector3.zero;
            spawedLaser.transform.localRotation = Quaternion.identity;*/
            spawedLaser.transform.position = firePoint.transform.position;
            spawedLaser.transform.rotation = firePoint.transform.rotation;
        }
    }

    void UpdateHit(RaycastHit hit)
    {
        spawnedHit.transform.rotation = Quaternion.LookRotation(hit.normal);
        spawnedHit.transform.position = hit.point;
    }

   /* private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ammo")
        {
            
            if (other.GetComponent<Ammo>().ammoType == "HA")
            {
                heavyAmmo += other.GetComponent<Ammo>().ammoVal;
            }

            Destroy(other.gameObject);
        }
    }*/



}
