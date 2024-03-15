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
        if(!inventoryIsOpen )
        {
            inventoryIsOpen = true;
            inventoryPanel.SetActive(true);
            inventoryData = InventoryDataManager.LoadInventory(inventoryIndex);
            for (int i = 0; i < inventoryData.slots.Length; i++)
            {
                inventorySlots[i] = inventoryData.slots[i];
                inventorySlots[i].UpdateItem();
            }
        }
        else
        {
            inventoryIsOpen = false;
            inventoryPanel.SetActive(false);
            InventoryDataManager.SaveInventory(inventoryIndex, inventoryData);
        }
    }
}
