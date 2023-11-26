using System;
using UnityEngine;

public class StoreManager : WindowBase, IUIWindow, IKeyBinded
{
    public delegate void ItemPurchasedEvent(FarmObjectData farmObjectData);
    public static ItemPurchasedEvent itemPurchased;

    [SerializeField] private PlayerData playerData; // Reference to player data
    private Transform currentSection;

    public KeyCode LocalKey { get => PlayerGameBinds.StoreKey; } // Get the key to open the Store

    private void Awake()
    {
        InitToList(this);
    }

   
    // Method to handle buying an object
    public void BuyObject(FarmObjectData farmObject)
    {
        if (playerData != null && farmObject != null)
        {
            if (playerData.CanAfford(farmObject.ObjectCost) && !farmObject.ItemPurchased())
            {
                playerData.AddItem(farmObject);
                playerData.DecreaseMoney(farmObject.ObjectCost); // Deduct the cost from the player's money
                farmObject.ItemPurchased(true); // Mark the item as purchased

                itemPurchased?.Invoke(farmObject);
                Debug.Log(farmObject + " was purchased"); // Log the purchase
            }
            else
                Debug.Log("Not enough money or object was purchased"); // Log if the player doesn't have enough money
        }
        else
            return;
    }
    public void CurrentSectionActive(Transform currentSection)
    {
        Debug.Log("Call" + currentSection);
        ClearSection();
        this.currentSection = currentSection;
        currentSection.gameObject.SetActive(true);
    }
    private void ClearSection()
    {
        if (currentSection != null)
            currentSection.gameObject.SetActive(false);
    }
    private void SellObject(FarmObjectData farmObject)
    {
        // To DO
    }

    public override void CloseUI(GameObject gameObject)
    {
        base.CloseUI(this.gameObject);
    }

    public override void OpenUI(GameObject gameObject)
    {
        base.OpenUI(this.gameObject);
    }


}
