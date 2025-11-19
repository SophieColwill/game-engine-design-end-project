using UnityEngine;

public class AtemptToSell : Observer
{
    EffectsManager manager;

    private void Start()
    {
        manager = FindAnyObjectByType<EffectsManager>();
    }

    public override void Notify(Subject subject)
    {
        Player localPlayer = subject.GetComponent<Player>();

        float currentCurrency = InventoryManager.Instance.Coins;
        localPlayer.CraftingRecipes[localPlayer.OnRecipe].TrySellItem();

        if (currentCurrency != InventoryManager.Instance.Coins)
        {
            manager.InitiateEffect(false);
        }
    }
}
