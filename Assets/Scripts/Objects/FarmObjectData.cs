using UnityEngine;

public class FarmObjectData : ScriptableObject
{
    public TypeObject typeObject;
    public GameObject prefab;
    [SerializeField] public Sprite image;
    [SerializeField] public string objectName;
    [SerializeField] public string description;
    [SerializeField] private bool itemWasPurchased = false;
    [SerializeField] private bool itemWasPlaced = false;
    public bool ItemPurchased() => itemWasPurchased;
    public bool ItemPlacesd() => itemWasPlaced;

    public bool ItemPurchased(bool purchased)
    {
        return itemWasPurchased = purchased;
    }
    public bool ItemPlacesd(bool wasPlacesd)
    {
        return itemWasPlaced = wasPlacesd;
    }

    [field: SerializeField] public int ObjectCost { get; private set; }

}
