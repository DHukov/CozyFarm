using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreItemUI : MonoBehaviour
{
    public ObjectData shopItem;
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text description;
    [SerializeField] private TMP_Text itemName;
    [SerializeField] private TMP_Text cost;
    [SerializeField] private Button buildiButton;
    [SerializeField] private GameObject purchasedInterface;


    private void Awake()
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

    public void ItemWasPurchased()
    {
        cost.gameObject.SetActive(false);
        buildiButton.gameObject.SetActive(true);
        purchasedInterface.gameObject.SetActive(true);

    }
}
