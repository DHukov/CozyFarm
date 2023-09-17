using UnityEngine;

public enum TypeObject
{
    Animals,
    Buildings,
    Plants,
    Default
}

public abstract class ItemObject : ScriptableObject
{
    public TypeObject typeObject;
    public GameObject prefab;
    public Sprite sprite;
    [field: SerializeField] public int Cost { get; private set; }
    public string itemName;
    public string description;

}
