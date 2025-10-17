using System.Collections.Generic;
using UnityEngine;

public abstract class ResourceRecipe
{
    public abstract List<InventoryItem> RequiredItems();
    public abstract InventoryItem Output();
    public abstract void TryMakeItem();

    protected bool HasEnoughOfRequiredItem()
    {
        bool output = true;
        if (RequiredItems().Count > 0)
        {
            for (int i = 0; i < RequiredItems().Count; i++)
            {
                output = InventoryManager.Instance.CheckInventory(RequiredItems()[i].ItemName);

                if (!output)
                {
                    i = RequiredItems().Count;
                }
            }
        }

        return output;
    }

    public void TrySellItem()
    {
        InventoryManager.Instance.TrySellInventory(Output().ItemName);
    }
}
