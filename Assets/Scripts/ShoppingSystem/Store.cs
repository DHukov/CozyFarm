using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class Store : UserInterface, IUIController
{
    [SerializeField] private List<ObjectData> shopInventory = new List<ObjectData>();
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private PlayerData playerData;

    // Property to get the local key for the Store UI
    public new KeyCode LocalKey { get => ControllerMenuSettings.StoreKey; }

    private void Start()
    {
        gameObject.SetActive(false);
    }
    // Method to handle buying an object
    public void BuyObject(ObjectData farmObject)
    {
        if (playerManager != null && playerData != null)
        {
            if (playerManager.CanAfford(farmObject.ObjectCost))
            {
                playerData.SetAmountMoney(-farmObject.ObjectCost);
                playerManager.playerInventory.Add(farmObject);
            }
            else
                Debug.Log("Not enough money");
        }
    }

    // Method to handle selling an object
    public void SellObject(ObjectData farmObject)
    {
        playerManager.playerInventory.Remove(farmObject);
        playerData.SetAmountMoney(farmObject.ObjectCost % 2);
    }

    // Method to close the Store UI
    public override void CloseUI(KeyCode keyCode)
    {
        gameObject.SetActive(false);
        base.CloseUI(LocalKey);

    }

    // Method to open the Store UI
    public override void OpenUI(KeyCode keyCode)
    {
        gameObject.SetActive(true);
        base.OpenUI(LocalKey);
    }
}
