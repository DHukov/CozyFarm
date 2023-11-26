using System.Collections.Generic;
using UnityEngine;

public class SpawnPointManager : MonoBehaviour, IObjectPlacer
{
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();
    private Vector3 contactSpawnPoint;

    private Vector3 GetSpawnPositionByPlayer()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            if (Interactor.currentInteractObject != null)
            {
                if (Interactor.currentInteractObject.transform.IsChildOf(spawnPoint))
                {
                    contactSpawnPoint = spawnPoint.position;
                    Debug.Log(contactSpawnPoint);
                }
            }
        }
        return contactSpawnPoint;
    }

    public void PlaceObject(FarmObjectData objectData)
    {
        //Transform transform += CurrentPosition();
        FarmFactory farmFactory = new FarmCreator();
        if (objectData != null)
        {
            switch (objectData.typeObject)
            {
                case TypeObject.Animals:
                    farmFactory.CreateAnimal((AnimalObjectData)objectData, GetSpawnPositionByPlayer());
                    break;
                case TypeObject.Buildings:
                    farmFactory.CreateBuilding((BuildObjectData)objectData, GetSpawnPositionByPlayer());
                    break;
                case TypeObject.Plants:
                    farmFactory.CreatePlant((PlantObjectData)objectData, GetSpawnPositionByPlayer());
                    break;
                case TypeObject.Default:
                    break;
                default:
                    break;
            }
        }
        else
            return;
        
    }
}
