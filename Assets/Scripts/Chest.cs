using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] GameObject interactIndication;
    bool isInteractable = false, inventoryIsOpen = false;
    InventoryManager inventoryManager;
    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GetComponent<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInteractable)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(Time.timeScale == 0)
                {
                    Time.timeScale = 1;
                }
                else
                {
                    Time.timeScale = 0;
                }
                
                inventoryManager.OpenCloseInventory();
                interactIndication.SetActive(!interactIndication.activeInHierarchy);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInteractable = true;
            interactIndication.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInteractable = false;
            interactIndication.SetActive(false);
        }
    }
}
