using UnityEngine;

[CreateAssetMenu(fileName = "New Object", menuName = "Shopping System/Items/Default")]
public class DefaultObject : ItemObject
{
    private void Awake()
    {
        typeObject = TypeObject.Default;
    }

}