using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slot : MonoBehaviour
{
    private inventory inventory;
    private GameObject player;
    public int i;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<inventory>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (transform.childCount <= 0)
        {
            inventory.isFool[i] = false;
        }
    }

    public void DropItem()
    {
        foreach(Transform child in transform)
        {
            if (child.CompareTag("Sword"))
            {
                player.GetComponent<PlayerController>().swordPickedUp = false;
            }
            child.GetComponent<spawn>().SpawnDroppedItem();
            GameObject.Destroy(child.gameObject);
        }
    }


}
