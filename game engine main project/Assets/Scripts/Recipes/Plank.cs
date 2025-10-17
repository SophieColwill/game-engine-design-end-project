using System.Collections.Generic;
using UnityEngine;

public class Plank : ResourceRecipe
{
    public override List<InventoryItem> RequiredItems()
    {
        InventoryItem Item1 = new InventoryItem();
        Item1.ItemName = "Log";


        List<InventoryItem> output = new List<InventoryItem>();
        output.Add(Item1);

        return output;
    }

    public override InventoryItem Output()
    {
        InventoryItem output = new InventoryItem();
        output.ItemName = "Plank";
        output.MultiplicationValue = 2;

        return output;
    }

    public override void TryMakeItem()
    {
        if (HasEnoughOfRequiredItem())
        {
            foreach (InventoryItem item in RequiredItems())
            {
                InventoryManager.Instance.removeItemFromInventory(item.ItemName);
            }

            InventoryManager.Instance.AddItemToInventory(Output().ItemName, Output().MultiplicationValue);
        }
    }
}
