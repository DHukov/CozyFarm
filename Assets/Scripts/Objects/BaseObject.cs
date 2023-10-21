using UnityEngine;

public abstract class BaseObject : MonoBehaviour, IInteractable
{
    public static ObjectData objectData;
    public virtual void Interact()
    {
        Debug.Log("You are trying interact for " + name);
    }
}
