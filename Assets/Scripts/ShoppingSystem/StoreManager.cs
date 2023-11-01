﻿using System.Collections.Generic;
using UnityEngine;

public class StoreManager : WindowBase, IWindow, IKeyBinded
{
    //[SerializeField] private List<GameObject> itemShopList = new List<GameObject>(); // List of shop items in the UI
    [SerializeField] private PlayerData playerData; // Reference to player data
    public static StoreManager Instance; // Static instance of the Store

    public KeyCode LocalKey { get => PlayerGameBinds.StoreKey; } // Get the key to open the Store

    private void Awake()
    {
        if (Instance == null)
            Instance = this; // Set the static instance to this object
        else
            Destroy(Instance); // Destroy this object if another instance already exists
    }

    // Method to handle buying an object
    public void BuyObject(FarmObjectData farmObject)
    {
        if (playerData != null && farmObject != null)
        {
            if (PlayerManager.Instance.CanAfford(farmObject.ObjectCost) && !farmObject.ItemPurchased(farmObject))
            {
                PlayerManager.playerPurchasedObjects.Add(farmObject); // Add the purchased item to the player's inventory
                playerData.DecreaseMoney(farmObject.ObjectCost); // Deduct the cost from the player's money

                farmObject.ItemPurchased(true); // Mark the item as purchased

                Debug.Log(farmObject + " was purchased"); // Log the purchase
            }
            else
                Debug.Log("Not enough money or object was purchased"); // Log if the player doesn't have enough money
        }
        else
            return;

       
    }

    // Method to handle selling an object
    public void SellObject(FarmObjectData farmObject)
    {
        // To DO
    }

    // Method to close the Store UI
    public override void CloseUI(GameObject gameObject)
    {
        base.CloseUI(gameObject);
    }

    // Method to open the Store UI
    public override void OpenUI(GameObject gameObject)
    {
        base.OpenUI(this.gameObject);
    }
}
