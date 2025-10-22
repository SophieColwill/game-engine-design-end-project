using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int OnRecipe = 0;
    [SerializeField] TMP_Text ItemNameBox;
    [SerializeField] TMP_Text ItemInputBox;
    [SerializeField] TMP_Text InInventoryBox;
    [SerializeField] TMP_Text CoinBox;

    #region Serialised Recipes
    List<ResourceRecipe> CraftingRecipes = new List<ResourceRecipe>();
    private void Start()
    {
        CraftingRecipes.Add(new Log());
        CraftingRecipes.Add(new Plank());
        CraftingRecipes.Add(new Rock());
        CraftingRecipes.Add(new Iron());
        CraftingRecipes.Add(new Brick());
        CraftingRecipes.Add(new Hammer());
        CraftingRecipes.Add(new Campfire());
        CraftingRecipes.Add(new Charcoal());
    }
    #endregion

    public void TryMake()
    {
        CraftingRecipes[OnRecipe].TryMakeItem();
        InInventoryBox.text = "In Inventory: " + InventoryManager.Instance.GetCurrentInventoryItem(CraftingRecipes[OnRecipe].Output().ItemName);
        UpdateRequiredItemsBox();
    }

    public void TrySell()
    {
        CraftingRecipes[OnRecipe].TrySellItem();
        InInventoryBox.text = "In Inventory: " + InventoryManager.Instance.GetCurrentInventoryItem(CraftingRecipes[OnRecipe].Output().ItemName);
        CoinBox.text = "Gold: " + Mathf.RoundToInt(InventoryManager.Instance.Coins);
    }

    public void SwitchCurrentItem(bool up)
    {
        if (up)
        {
            OnRecipe++;
            if (OnRecipe == CraftingRecipes.Count)
            {
                OnRecipe = 0;
            }
        }
        else
        {
            OnRecipe--;
            if (OnRecipe == -1)
            {
                OnRecipe = CraftingRecipes.Count - 1;
            }
        }

        ItemNameBox.text = CraftingRecipes[OnRecipe].Output().ItemName;
        InInventoryBox.text = "In Inventory: " + InventoryManager.Instance.GetCurrentInventoryItem(CraftingRecipes[OnRecipe].Output().ItemName);
        UpdateRequiredItemsBox();
    }

    void UpdateRequiredItemsBox()
    {

        if (CraftingRecipes[OnRecipe].RequiredItems().Count > 0)
        {
            ItemInputBox.text = "Required Items:\n";

            foreach(InventoryItem item in CraftingRecipes[OnRecipe].RequiredItems())
            {
                ItemInputBox.text += item.ItemName + " (" + InventoryManager.Instance.GetCurrentInventoryItem(item.ItemName) + ")\n";
            }
        }
        else
        {
            ItemInputBox.text = "";
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
