using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    public Camera fpsCam;
    public float findRange;

    // Update is called once per frame
    void Update()
    {
        Ray itemRay = new Ray(fpsCam.transform.position, fpsCam.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(itemRay,out hit,findRange))
        {

            PickUpItem(hit);
            OpenPassword(hit);
            OpenKeypad(hit);
            OpenDatapad(hit);
            TalkToRobot(hit);
            GrabPickup(hit);
            PressButton(hit);
        }

    }

    bool CheckItem(RaycastHit hit)
    {
        if (hit.transform.tag == "Item")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool CheckPassword(RaycastHit hit)
    {
        if (hit.transform.tag == "Password")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool CheckKeypad(RaycastHit hit)
    {
        if (hit.transform.tag == "Keypad")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool CheckDatapad(RaycastHit hit)
    {
        if (hit.transform.tag == "Datapad")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool CheckRobot(RaycastHit hit)
    {
        if (hit.transform.tag == "Robot")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool CheckPickup(RaycastHit hit)
    {
        if (hit.transform.tag == "Pickup")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool CheckButton(RaycastHit hit)
    {
        if (hit.transform.tag == "Button")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void PickUpItem(RaycastHit hit)
    {

        if(CheckItem(hit) && Input.GetKeyDown("e"))
        {

            Debug.Log("Picked Up Item");
            Inventory.instance.AddItem(hit.transform.GetComponent<Weapon>().WeaponType);
            Destroy(hit.transform.gameObject);

        }

    }

    void OpenPassword(RaycastHit hit)
    {

        if (CheckPassword(hit) && Input.GetKeyDown("e"))
        {

            hit.transform.GetComponent<Password>().OpenPassword();

        }

    }

    void OpenKeypad(RaycastHit hit)
    {

        if (CheckKeypad(hit) && Input.GetKeyDown("e"))
        {

            hit.transform.GetComponent<Keypad>().UseKeypad();

        }

    }

    void TalkToRobot(RaycastHit hit)
    {
        if(CheckRobot(hit) && Input.GetKeyDown("e"))
        {
            hit.transform.GetComponent<Drone>().StartDialogue(false);
        }
    }

    void GrabPickup(RaycastHit hit)
    {
        if (CheckPickup(hit) && Input.GetKeyDown("e"))
        {
            hit.transform.GetComponent<Pickup>().PickedUp();
        }
    }

    void PressButton(RaycastHit hit)
    {
        if (CheckButton(hit) && Input.GetKeyDown("e"))
        {
            hit.transform.GetComponent<MinigameButton>().Press();
        }
    }
    void OpenDatapad(RaycastHit hit)
    {

        if (CheckDatapad(hit) && Input.GetKeyDown("e"))
        {

            if (hit.transform.GetComponent<Datapad>() != null)
            {
                hit.transform.GetComponent<Datapad>().OpenDatapad();
            }
            else
            {
                hit.transform.GetComponent<InfoDump>().isActive = true;
            }

        }

    }

}
