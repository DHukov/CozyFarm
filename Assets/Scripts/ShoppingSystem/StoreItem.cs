using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreItem : MonoBehaviour
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
       
    }
    private void OnEnable() => StoreManager.itemPurchased += ItemWasPurchased;
    private void OnDisable() => StoreManager.itemPurchased -= ItemWasPurchased;
    private void ItemWasPurchased(FarmObjectData purchasedItems)
    {
        if (shopItem == purchasedItems)
        {
            Debug.LogError("Action");
            cost.gameObject.SetActive(false);
            buildButton.gameObject.SetActive(true);
            purchasedInterface.gameObject.SetActive(true);
        }
    }
}
