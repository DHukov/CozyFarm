using System.Collections.Generic;
using UnityEngine;

interface IPlacement
{
    public void SetObjectPosition(ObjectData objectData, Vector3 vector3);

}
public class ObjectInitilizeAction : MonoBehaviour
{
    private IPlacement placement;
    [SerializeField] private List<Transform> buildingsPosition = new List<Transform>();

    private void Awake()
    {

    }
    public void PlaceObject(ObjectData objectData)
    {
        foreach (var item in PlayerManager.playerInventory)
        {
            if (objectData == item)
            {
                switch (item.typeObject)
                {
                    case TypeObject.Animals:
                        //placement.SetObjectPosition(objectData, Vector3());
                        break;
                    case TypeObject.Buildings:
                        PlaceBuilding(item);
                        break;
                    case TypeObject.Plants:
                        break;
                    case TypeObject.Default:
                        break;
                    default:
                        break;
                }
            }
        }
    }

    private void PlaceBuilding(ObjectData item)
    {
        Debug.Log("Spawn");
    }
}
