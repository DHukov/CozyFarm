using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreItemUI : MonoBehaviour
{
    public ObjectData shopItem;
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private TMP_Text _itemName;
    [SerializeField] private TMP_Text _cost;
    private void Awake()
    {
        if (shopItem == null)
            return;
        else 
        {
            _image.sprite = shopItem.image;
            _description.text = shopItem.description;
            _itemName.text = shopItem.objectName;
            _cost.text = shopItem.ObjectCost.ToString();
        }
    }
}
