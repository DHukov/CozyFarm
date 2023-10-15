using UnityEngine;

public abstract class BaseObject : MonoBehaviour, IInteractable
{
    public static ObjectData objectData;
    public virtual void Interact()
    {
        Debug.LogWarning("You are trying interact for Base Figure " + name);
    }
}
