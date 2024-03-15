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
        Stream stream = File.Open($"SaveData/Inventories/Inventory{index}.xml", FileMode.Create);
        XmlSerializer serializer = new XmlSerializer(typeof(InventoryData));
        serializer.Serialize(stream, inventoryData);
        stream.Close();
    }

    public static InventoryData LoadInventory(int index)
    {
        Directory.CreateDirectory("SaveData/Inventories");
        if (File.Exists($"SaveData/Inventories/Inventory{index}.xml"))
        {
            Stream stream = File.Open($"SaveData/Inventories/Inventory{index}.xml", FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(InventoryData));
            InventoryData loadedData = (InventoryData)serializer.Deserialize(stream);
            stream.Close();
            return loadedData;
        }
        else
        {
            return null;
        }
    }
}

public class InventoryData
{
    public SlotData[] slots;

    public InventoryData()
    {
        slots = new SlotData[9];
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = new SlotData();
        }
    }
}

public class SlotData
{
    public ItemScriptableObject item;
    public SlotData()
    {
        item = null;
    }
}


