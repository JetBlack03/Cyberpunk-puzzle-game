using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayItemName : MonoBehaviour
{
    public Camera fpsCam;
    public float findRange;

    public Text itemName;
    public Text interactableName;

    public Text useKeypadPtompt;
    public Text keypadName;

    public Text usePasswordPtompt;
    public Text passwordName;

    public Text useDatapadPtompt;
    public Text datapadName;



    public Text itemPickUpPtompt;

    // Update is called once per frame
    void Update()
    {

        Ray displayRay = new Ray(fpsCam.transform.position, fpsCam.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(displayRay, out hit, findRange))
        {
            DisplayAction(hit);
            DisplayItem(hit);
            DisplayKeypad(hit);
            DisplayPassword(hit);
            DisplayDatapad(hit);
            DisplayRobot(hit);
            DisplayPickup(hit);
            DisplayButton(hit);
        }
        else
        {
            itemName.text = null;
            interactableName.text = null;
            itemPickUpPtompt.text = null;
            keypadName.text = null;
            useKeypadPtompt.text = null;
            usePasswordPtompt.text = null;
            passwordName.text = null;
            datapadName.text = null;
            useDatapadPtompt.text = null;
            
        }

    }

    bool CheckInteractable(RaycastHit hit)
    {

        if (hit.transform.tag == "Interactable")
        {
            
            return true;
        }
        else
        {
            return false;
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

    void DisplayAction(RaycastHit hit)
    {

        if (CheckInteractable(hit))
        {

            interactableName.text = hit.transform.name;
        }
        else
        {
            interactableName.text = null;
        }

    }

    void DisplayItem(RaycastHit hit)
    {
        if (CheckItem(hit))
        {
            itemName.text = hit.transform.name;
            itemPickUpPtompt.text = "Press E to Pick Up";
        }
        else
        {
            itemName.text = null;
            itemPickUpPtompt.text = null;
        }
    }

    void DisplayPassword(RaycastHit hit)
    {
        if (CheckPassword(hit))
        {
            passwordName.text = "Computer Terminal";
            usePasswordPtompt.text = "Press E to Use";
        }
        else
        {
            passwordName.text = null;
            usePasswordPtompt.text = null;
        }
    }

    void DisplayKeypad(RaycastHit hit)
    {
        if (CheckKeypad(hit))
        {
            keypadName.text = "Keypad";
            useKeypadPtompt.text = "Press E to Use";
        }
        else
        {
            keypadName.text = null;
            useKeypadPtompt.text = null;
        }
    }

    void DisplayRobot(RaycastHit hit)
    {
        if (CheckRobot(hit))
        {
            keypadName.text = hit.collider.gameObject.name;
            useKeypadPtompt.text = "Press E to interact";
        }
        else
        {
         //   keypadName.text = null;
           // useKeypadPtompt.text = null;
        }
    }
    void DisplayPickup(RaycastHit hit)
    {
        if (CheckPickup(hit))
        {
            keypadName.text = hit.collider.gameObject.name;
            useKeypadPtompt.text = "Press E to pick up";
        }
        else
        {
            //   keypadName.text = null;
            // useKeypadPtompt.text = null;
        }
    }
    void DisplayButton(RaycastHit hit)
    {
        if (CheckButton(hit))
        {
            keypadName.text = hit.collider.gameObject.name;
            useKeypadPtompt.text = "Press E to start";
        }
        else
        {
            //   keypadName.text = null;
            // useKeypadPtompt.text = null;
        }
    }

    void DisplayDatapad(RaycastHit hit)
    {
        if (CheckDatapad(hit))
        {
            datapadName.text = "Datapad";
            useDatapadPtompt.text = "Press E to Use";
        }
        else
        {
            datapadName.text = null;
            useDatapadPtompt.text = null;
        }
    }


}
