using CostCalculator;
using System.Collections.Generic;
using UnityEngine;

public class Campfire : ResourceRecipe
{
    public override List<InventoryItem> RequiredItems()
    {
        InventoryItem Item1 = new InventoryItem();
        Item1.ItemName = "Rock";
        InventoryItem Item2 = new InventoryItem();
        Item2.ItemName = "Plank";


        List<InventoryItem> output = new List<InventoryItem>();
        output.Add(Item1);
        output.Add(Item2);

        return output;
    }

    public override InventoryItem Output()
    {
        InventoryItem output = new InventoryItem();
        output.ItemName = "Campfire";

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
