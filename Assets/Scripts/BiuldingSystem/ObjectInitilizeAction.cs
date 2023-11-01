using System.Collections.Generic;
using UnityEngine;

interface IPlacement
{
    public void SetObjectPosition(FarmObjectData objectData, Vector3 vector3);

}
public class ObjectInitilizeAction : MonoBehaviour
{
    private IPlacement placement;
    [SerializeField] private List<Transform> buildingsPosition = new List<Transform>();


    public void PlaceObject(FarmObjectData objectData)
    {
        foreach (var item in PlayerManager.playerPurchasedObjects)
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

    private void PlaceBuilding(FarmObjectData item)
    {
        Debug.Log("Spawn");
    }
}
