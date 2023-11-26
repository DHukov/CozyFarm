using UnityEngine;

public class FarmCreator : FarmFactory
{
    public override Animal CreateAnimal(AnimalObjectData animalObjectData, Vector3 position)
    {
        var go = GameObject.Instantiate(animalObjectData.prefab, position, new Quaternion(0,0,0,0));
        var animal = go.GetComponent<Animal>(); ;
        return animal;
    }

    public override Building CreateBuilding(BuildObjectData buildObjectData, Vector3 position)
    {
        var go = GameObject.Instantiate(buildObjectData.prefab, position, new Quaternion(0, 0, 0, 0));
        var building = go.GetComponent<Building>();
        return building;
    }

    public override Plant CreatePlant(PlantObjectData plantObjectData, Vector3 position)
    {
        var go = GameObject.Instantiate(plantObjectData.prefab, position, new Quaternion(0, 0, 0, 0));
        var plant = go.GetComponent<Plant>();
        return plant;
    }
}
