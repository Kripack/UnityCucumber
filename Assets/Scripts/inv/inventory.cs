using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory : MonoBehaviour
{
    public bool[] isFool;
    public GameObject[] slots;
    public GameObject Inventory;
    private bool inventoryOn;

    private void Start()
    {
        inventoryOn = false;
        Inventory.SetActive(false);
    }

    public void Bag()
    {
        if (!inventoryOn)
        {
            inventoryOn = true;
            Inventory.SetActive(true);
        }
        else if (inventoryOn)
        {
            inventoryOn = false;
            Inventory.SetActive(false);
        }
    }

}
