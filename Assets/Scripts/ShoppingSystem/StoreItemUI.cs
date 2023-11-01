using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreItemUI : MonoBehaviour
{
    [SerializeField] private FarmObjectData shopItem;
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text description;
    [SerializeField] private TMP_Text itemName;
    [SerializeField] private TMP_Text cost;
    [SerializeField] private Button buildButton;
    [SerializeField] private GameObject purchasedInterface;


    private void Start()
    {
        if (shopItem == null)
            return;
        else 
        {
            image.sprite = shopItem.image;
            description.text = shopItem.description;
            itemName.text = shopItem.objectName;
            cost.text = shopItem.ObjectCost.ToString();
        }
    }
    public FarmObjectData GetFarmObjectData() => shopItem;
    private void Update()
    {
        if (shopItem == null)
            return;
        else
        ItemWasPurchased(shopItem.ItemPurchased());
    }
    public void ItemWasPurchased(bool ItemPurchased)
    {
        if (ItemPurchased)
        {
            cost.gameObject.SetActive(false);
            buildButton.gameObject.SetActive(true);
            purchasedInterface.gameObject.SetActive(true);

        }
    }


}
