using UnityEngine;


public class BuildObject : BaseObject
{
    public BuildObjectData buildingObject;
    private void Awake()
    {

    }
    public override void Interact()
    {
        //Debug.Log("Spec Interact");
        base.Interact();
    }
}
