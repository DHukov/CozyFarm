using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingUI : MonoBehaviour
{
    public ItemObject shopItems;
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private TMP_Text _itemName;
    [SerializeField] private TMP_Text _cost;

    // Start is called before the first frame update
    void Start()
    {
        _image.sprite = shopItems.sprite;
        _description.text = shopItems.description;
        _itemName.text = shopItems.itemName;
        _cost.text = shopItems.Cost.ToString();

    }
    public void debug()
    {
        Debug.Log("Button");
    }

}
