using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    private inventory inventory;
    public GameObject slotButton;
    private GameObject player;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<inventory>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFool[i] == false)
                {
                    if (slotButton.CompareTag("Sword"))
                    {
                        player.GetComponent<PlayerController>().swordPickedUp = true;
                    }
                    inventory.isFool[i] = true;
                    Instantiate(slotButton, inventory.slots[i].transform);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
