using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Inventory : MonoBehaviour
{

    public static Inventory instance;
    public int inventorySize;
    public List<Item> items = new List<Item>();
    public bool autoAdd;
    public bool hasCalled;

    public Item tool1;
    public Item tool2;
    public Item tool3;

    public GameObject pickup;
    public TextMeshProUGUI pickupText;

    private void Awake()
    {

        if(instance != null)
        {
            Debug.LogError("To many inventorys");
            return;
        }

        instance = this;
    }

    void Update()
    {
        if(autoAdd == true && hasCalled == false)
        {
            AddItem(tool1);
            AddItem(tool2);
            AddItem(tool3);
            hasCalled = true;
        }
    }



    public void AddItem(Item item)
    {
        if(items.Count <= inventorySize)
        {
            items.Add(item);
        }
        
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }

    public void PickUpObject(GameObject pickupObject)
    {
        if(pickup != null && pickup != pickupObject)
        {
            pickup.GetComponent<Pickup>().Drop();
        }
        pickup = pickupObject;
        pickupText.text = "Holding " + pickupObject.name;
    }

    public void RemoveObject()
    {
        pickup = null;
        pickupText.text = "";
    }

}
