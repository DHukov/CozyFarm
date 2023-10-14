using UnityEngine;


public class WaterPump : BaseObject
{
    public BuildObjectData buildingObject;
    public float litersOfWater;

    public override void Interact()
    {
        litersOfWater += Time.time;
        Debug.Log(litersOfWater);

    }
}
