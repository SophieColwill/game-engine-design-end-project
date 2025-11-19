using UnityEngine;

public class ChangeCurrencyValue : Observer
{
    public override void Notify(Subject subject)
    {
        Player localPlayer = subject.GetComponent<Player>();

        localPlayer.CoinBox.text = "Gold: " + Mathf.RoundToInt(InventoryManager.Instance.Coins);
    }
}
