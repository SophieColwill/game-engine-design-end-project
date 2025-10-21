using System.Collections.Generic;
using UnityEngine;
using CostCalculator;

public class Log : ResourceRecipe
{
    public override List<InventoryItem> RequiredItems()
    {
        return new List<InventoryItem>(0);
    }

    public override InventoryItem Output()
    {
        InventoryItem output = new InventoryItem();
        output.ItemName = "Log";

        return output;
    }

    public override void TryMakeItem()
    {
        InventoryManager.Instance.AddItemToInventory(Output().ItemName, Calculator.NewCost(new List<float>()));
    }
}
