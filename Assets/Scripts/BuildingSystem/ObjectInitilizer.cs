using System;
using UnityEngine;


public class ObjectInitilizer : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        if (PlayerData.CurrentInventoryItem != null)
        {
            var go = Interactor.currentInteractObject.GetComponentInParent<IObjectPlacer>();
            go.PlaceObject(PlayerData.CurrentInventoryItem);
        }
        else
            return;
    }
}
