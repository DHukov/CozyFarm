using System.Collections.Generic;
using UnityEngine;

public class MarketManager : MonoBehaviour
{
    [SerializeField] private List<ObjectData> shopInventory = new List<ObjectData>();
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private PlayerData playerData;

    private void Update()
    {

    }
   
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
    public void SellObject(ObjectData farmObject)
    {
        playerManager.playerInventory.Remove(farmObject);
        playerData.SetAmountMoney(+(farmObject.ObjectCost % 2));
    }
}
