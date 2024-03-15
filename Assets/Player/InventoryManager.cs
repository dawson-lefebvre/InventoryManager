using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int inventoryIndex = 0; //0 is player
    bool inventoryIsOpen = false;
    [SerializeField] GameObject inventoryPanel;
    InventoryData inventoryData;
    [SerializeField] List<UIItemSlot> inventorySlots;
    public void OpenCloseInventory()
    {
        if(!inventoryIsOpen)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            inventoryIsOpen = true;
            inventoryPanel.SetActive(true);
            inventoryData = InventoryDataManager.LoadInventory(inventoryIndex);
            if(inventoryData != null )
            {
                for (int i = 0; i < inventoryData.slots.Length; i++)
                {
                    inventorySlots[i].currentItem = inventoryData.slots[i].item;
                    inventorySlots[i].UpdateItem();
                }
            }
            else
            {
                inventoryData = new InventoryData();
                for (int i = 0; i < inventorySlots.Count; i++)
                {
                    inventorySlots[i].UpdateItem();
                }
            }
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            inventoryIsOpen = false;
            inventoryPanel.SetActive(false);

            for (int i = 0; i < inventorySlots.Count; i++)
            {
                inventoryData.slots[i].item = inventorySlots[i].currentItem;
            }

            InventoryDataManager.SaveInventory(inventoryIndex, inventoryData);
        }
    }
}
