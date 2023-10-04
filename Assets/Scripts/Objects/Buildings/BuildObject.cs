using UnityEngine;


public class BuildObject : BaseObject
{
    public BuildObjectData buildingObject;
    public float litersOfWater;
    private void Awake()
    {

    }
    public override void Interact()
    {
        litersOfWater += Time.time;
        Debug.Log(litersOfWater);

    }
}
