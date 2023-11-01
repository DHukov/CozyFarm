using UnityEngine;

public abstract class BaseObject : MonoBehaviour, IInteractable
{
    public static FarmObjectData objectData;


    public virtual void Interact()
    {
        Debug.Log("You are trying interact for " + name);
    }
}

public abstract class ObjectCreator
{
    public abstract BaseObject FactoryMethod(PlayerManager playerManager);

}
public class BuildCreator : ObjectCreator
{
    public override BaseObject FactoryMethod(PlayerManager playerManager)
    {
        //var prefab = Resources.Load<GameObject>("Prefabs/WaterPump");
        //var go = PlayerManager.playerPurchasedObjects[0].prefab.GetComponent<BaseObject>();
        var go = playerManager.CurrentFarmObject.prefab.GetComponent<BaseObject>();
        return go;
    }
}