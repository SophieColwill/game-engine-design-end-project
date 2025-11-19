using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Subject
{
    public int OnRecipe = 0;
    [SerializeField] TMP_Text ItemNameBox;
    [SerializeField] TMP_Text ItemInputBox;
    public TMP_Text InInventoryBox;
    public TMP_Text CoinBox;

    EffectsManager manager;

    #region Serialised Recipes
    [HideInInspector]public List<ResourceRecipe> CraftingRecipes = new List<ResourceRecipe>();
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

        Attach(gameObject.AddComponent<AtemptToSell>());
        Attach(gameObject.AddComponent<ChangeInventoryUI>());
        Attach(gameObject.AddComponent<ChangeCurrencyValue>());

        manager = FindAnyObjectByType<EffectsManager>();
    }
    #endregion

    public void TryMake()
    {
        int lastAmountOfItem = InventoryManager.Instance.GetCurrentInventoryItem(CraftingRecipes[OnRecipe].Output().ItemName);

        CraftingRecipes[OnRecipe].TryMakeItem();

        int CurrentAmountOfItem = InventoryManager.Instance.GetCurrentInventoryItem(CraftingRecipes[OnRecipe].Output().ItemName);
        InInventoryBox.text = "In Inventory: " + CurrentAmountOfItem;
        UpdateRequiredItemsBox();

        if (CurrentAmountOfItem != lastAmountOfItem)
        {
            manager.InitiateEffect(true);
        }
    }

    public void TrySell()
    {
        NotifyObservers();
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
