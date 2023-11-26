using UnityEngine;

public abstract class FarmFactory
{
    public abstract Animal CreateAnimal(AnimalObjectData animalObjectData, Vector3 position);
    public abstract Building CreateBuilding(BuildObjectData buildObjectData, Vector3 position);
    public abstract Plant CreatePlant(PlantObjectData plantObjectData, Vector3 position);
}
