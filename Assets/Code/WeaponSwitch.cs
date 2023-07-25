using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponSwitch : MonoBehaviour
{

    public Item activeWeapon;

    public static WeaponSwitch instance;
    public TextMeshProUGUI textDisplay;

    public GameObject[] shines;


    private void Awake()
    {

        if (instance != null)
        {
            Debug.LogError("To many weaponsScripts");
            return;
        }

        instance = this;
    }

    void Start()
    {
        if(Inventory.instance.items[0] != null)
        {
            activeWeapon = Inventory.instance.items[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Inventory.instance.items.Count == 1)
        {
            activeWeapon = Inventory.instance.items[0];
        }

        if (Input.GetKeyDown("1") && Inventory.instance.items[0] != null && Input.GetMouseButton(0) == false)
        {
            activeWeapon = Inventory.instance.items[0];
            textDisplay.text = "Plasma Orb is selected";
            shines[0].SetActive(true);
            shines[1].SetActive(false);
            shines[2].SetActive(false);
        }

        if (Input.GetKeyDown("2") && Inventory.instance.items[1] != null && Input.GetMouseButton(0) == false)
        {
            activeWeapon = Inventory.instance.items[1];
            textDisplay.text = "Electro Orb is selected";
            shines[0].SetActive(false);
            shines[1].SetActive(true);
            shines[2].SetActive(false);
        }

        if (Input.GetKeyDown("3") && Inventory.instance.items[2] != null && Input.GetMouseButton(0) == false)
        {   
            activeWeapon = Inventory.instance.items[2];
            textDisplay.text = "Mining Laser is selected";
            shines[0].SetActive(false);
            shines[1].SetActive(false);
            shines[2].SetActive(true);
        }

    }
}
