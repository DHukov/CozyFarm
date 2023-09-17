using UnityEngine;

[CreateAssetMenu(fileName = "New Object", menuName = "Shopping System/Items/Buildings")]

public class BuildObjects : ItemObject
{
    private void Awake()
    {
        typeObject = TypeObject.Buildings;
    }

}
