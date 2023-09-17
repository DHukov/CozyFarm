using UnityEngine;
public class Item : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemObject itemObject;
    public void Interact()
    {
        Debug.Log("Interact");
    }
  
}
