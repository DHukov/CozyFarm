using UnityEngine;

public enum TypeObject
{
    Animals,
    Buildings,
    Plants,
    Default
}

public abstract class BaseObject : MonoBehaviour, IInteractable
{
    public static ObjectData objectData;
    public virtual void Interact()
    {
        Debug.LogWarning("You are trying interact for Base Figure " + name);
    }
}
