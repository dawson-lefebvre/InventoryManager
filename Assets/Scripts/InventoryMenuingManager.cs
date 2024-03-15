using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenuingManager : MonoBehaviour
{
    public UIItemSlot currentSelectedSlot;
    static public InventoryMenuingManager instance;

    private void Start()
    {
        instance = this;
    }

    public void SelectSlot(UIItemSlot slot)
    {
        if(currentSelectedSlot == slot) return;

        if(currentSelectedSlot == null)
        {
            currentSelectedSlot = slot;
            return;
        }
        else
        {
            SwitchSlots(slot);
        }
    }

    public void SwitchSlots(UIItemSlot slotToSwitch)
    {
        ItemScriptableObject objToSwitch;
        objToSwitch = currentSelectedSlot.currentItem;
        currentSelectedSlot.currentItem = slotToSwitch.currentItem;
        slotToSwitch.currentItem = objToSwitch;
        currentSelectedSlot.UpdateItem();
        slotToSwitch.UpdateItem();
        currentSelectedSlot = null;
    }
}
