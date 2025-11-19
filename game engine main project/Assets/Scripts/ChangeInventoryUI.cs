using UnityEngine;

public class ChangeInventoryUI : Observer
{
    public override void Notify(Subject subject)
    {
        Player localPlayer = subject.GetComponent<Player>();

        localPlayer.InInventoryBox.text = "In Inventory: " + InventoryManager.Instance.GetCurrentInventoryItem(localPlayer.CraftingRecipes[localPlayer.OnRecipe].Output().ItemName);
    }
}
