using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public static class InventoryDataManager
{
    public static void SaveInventory(int index, InventoryData inventoryData)
    {
        //Player is always index 0
        Directory.CreateDirectory("SaveData/Inventories");
        Stream stream = File.Open($"SaveData/Inventories/Inventory{index}", FileMode.Create);
        XmlSerializer serializer = new XmlSerializer(typeof(InventoryData));
        serializer.Serialize(stream, inventoryData);
        stream.Close();
    }

    public static InventoryData LoadInventory(int index)
    {
        if (File.Exists($"SaveData/Inventories/Inventory{index}"))
        {
            Stream stream = File.Open($"SaveData/Inventories/Inventory{index}", FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(InventoryData));
            InventoryData loadedData = (InventoryData)serializer.Deserialize(stream);
            stream.Close();
            return loadedData;
        }
        else
        {
            return new InventoryData(9);
        }
    }
}

public class InventoryData
{
    public UIItemSlot[] slots;

    public InventoryData(int numOfSlots)
    {
        slots = new UIItemSlot[numOfSlots];
    }
}

