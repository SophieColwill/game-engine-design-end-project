using CostCalculator;
using System.Collections.Generic;
using UnityEngine;

public class Charcoal : ResourceRecipe
{
    public override List<InventoryItem> RequiredItems()
    {
        InventoryItem Item1 = new InventoryItem();
        Item1.ItemName = "Campfire";
        InventoryItem Item2 = new InventoryItem();
        Item2.ItemName = "Log";


        List<InventoryItem> output = new List<InventoryItem>();
        output.Add(Item1);
        output.Add(Item2);

        return output;
    }

    public override InventoryItem Output()
    {
        InventoryItem output = new InventoryItem();
        output.ItemName = "Charcoal";

        return output;
    }

    public override void TryMakeItem()
    {
        if (HasEnoughOfRequiredItem())
        {
            List<float> AllCosts = new List<float>();

            foreach (InventoryItem item in RequiredItems())
            {
                InventoryManager.Instance.removeItemFromInventory(item.ItemName);
                AllCosts.Add(InventoryManager.Instance.GetCostOfItem(item.ItemName));
            }

            InventoryManager.Instance.AddItemToInventory(Output().ItemName, Calculator.NewCost(AllCosts));
        }
    }
}
