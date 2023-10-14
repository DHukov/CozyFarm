using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour, IUIController
{
    [SerializeField] private List<GameObject> itemShopList = new List<GameObject>(); // List of shop items in the UI
    [SerializeField] private PlayerData playerData; // Reference to player data
    public static Store Instance; // Static instance of the Store

    public KeyCode LocalKey { get => PlayerGameBinds.StoreKey; } // Get the key to open the Store

    private void Awake()
    {
        if (Instance == null)
            Instance = this; // Set the static instance to this object
        else
            Destroy(Instance); // Destroy this object if another instance already exists
    }

    // Method to handle buying an object
    public void BuyObject(ObjectData farmObject)
    {
        if (playerData != null)
        {
            foreach (var item in itemShopList)
            {
                if (PlayerManager.Instance.CanAfford(farmObject.ObjectCost) && !item.GetComponent<StoreItemUI>().shopItem.itemWasPurchased)
                {
                    PlayerManager.playerInventory.Add(farmObject); // Add the purchased item to the player's inventory
                    playerData.SetAmountMoney(-farmObject.ObjectCost); // Deduct the cost from the player's money

                    if (farmObject == item.GetComponent<StoreItemUI>().shopItem)
                    {
                        item.GetComponent<StoreItemUI>().ItemWasPurchased(); // Mark the item as purchased in the UI
                        item.GetComponent<StoreItemUI>().shopItem.itemWasPurchased = true; // Mark the item as purchased
                        Debug.Log(farmObject + " was purchased"); // Log the purchase
                    }
                }
            }
        }
        else
            Debug.Log("Not enough money"); // Log if the player doesn't have enough money
    }

    // Method to handle selling an object
    public void SellObject(ObjectData farmObject)
    {
        PlayerManager.playerInventory.Remove(farmObject); // Remove the sold item from the player's inventory
        playerData.SetAmountMoney(farmObject.ObjectCost % 2); // Add half of the item's cost to the player's money
    }

    // Method to close the Store UI
    public void CloseUI()
    {
        gameObject.SetActive(false); // Deactivate the Store UI
    }

    // Method to open the Store UI
    public void OpenUI()
    {
        gameObject.SetActive(true); // Activate the Store UI
    }
}
