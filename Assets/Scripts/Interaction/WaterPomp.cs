using UnityEngine;

public class WaterPomp : MonoBehaviour, IInteractable
{
    public int count;

    public void Interact()
    {
        count++;
        Debug.Log("Interact" + count);
    }
  
}
