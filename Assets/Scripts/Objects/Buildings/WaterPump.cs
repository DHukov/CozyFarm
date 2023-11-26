using UnityEngine;

public class WaterPump : Building// : BaseObject
{
    public BuildObjectData buildingObject;
    public float litersOfWater;


    public override void Interact()
    {
        litersOfWater += Time.time;
        //Debug.Log(litersOfWater);
        base.Interact();
    }
}
