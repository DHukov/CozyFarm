using UnityEngine;

public abstract class BaseFarmObject : MonoBehaviour, IInteractable
{
    public static FarmObjectData objectData;

    public virtual void Interact()
    {
        Debug.Log("You are trying interact for " + name);
    }
}
public abstract class Building : BaseFarmObject
{

}
public abstract class Animal : BaseFarmObject
{

}
public abstract class Plant : BaseFarmObject
{

}