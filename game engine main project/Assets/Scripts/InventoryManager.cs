using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : Singleton<InventoryManager>
{
    public float Coins;
    public List<InventoryItem> Inventory;

    public void AddItemToInventory(string ID, float newMultplicationValue)
    {
        bool isAlreadyInventorySlot = false;
        foreach (InventoryItem item in Inventory)
        {
            if (item.ItemName == ID)
            {
                isAlreadyInventorySlot = true;
                item.numberOfItem++;
                break;
            }
        }

        if (!isAlreadyInventorySlot)
        {
            InventoryItem newItem = new InventoryItem();
            newItem.MultiplicationValue = newMultplicationValue;
            newItem.ItemName = ID;
            newItem.numberOfItem = 1;
            Inventory.Add(newItem);
        }
    }

    public bool CheckInventory(string ItemName)
    {
        bool output = false;

        foreach (InventoryItem item in Inventory)
        {
            if (item.ItemName == ItemName)
            {
                if (item.numberOfItem > 0)
                {
                    output = true;
                }
                break;
            }
        }

        return output;
    }

    public void TrySellInventory(string ItemName)
    {
        foreach (InventoryItem item in Inventory)
        {
            if (item.ItemName == ItemName)
            {
                if (item.numberOfItem > 0)
                {
                    item.numberOfItem--;
                    Coins += item.MultiplicationValue;
                }
            }
        }
    }

    public void removeItemFromInventory(string ItemName)
    {
        foreach (InventoryItem item in Inventory)
        {
            if (item.ItemName == ItemName)
            {
                item.numberOfItem--;
            }
        }
    }

    public int GetCurrentInventoryItem(string ItemName)
    {
        int output = 0;

        foreach(InventoryItem item in Inventory)
        {
            if (item.ItemName == ItemName)
            {
                output = item.numberOfItem;
            }
        }

        return output;
    }

    public float GetCostOfItem(string ItemName)
    {
        float output = 0;

        foreach (InventoryItem item in Inventory)
        {
            if (item.ItemName == ItemName)
            {
                output = item.MultiplicationValue;
            }
        }

        return output;
    }
}
