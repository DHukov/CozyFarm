using UnityEngine;

public class Interactor : MonoBehaviour
{
    private Collider _currentInteractGO;
    [SerializeField] private KeyCode _keyCode;
    [SerializeField] private LayerMask _layerMask;
    IInteractable _interactable;
    public bool inCollider = false;

    private void Update()
    {
        CanPlayerInteract(inCollider);
        if (_currentInteractGO == null)
            return;
    }
    private void OnTriggerEnter(Collider other)
    {
        _interactable = other.gameObject.GetComponent(typeof(IInteractable)) as IInteractable;
        if (_interactable != null)
            inCollider = true;
    }
    private void CanPlayerInteract(bool canPressButton)
    {
        if (Input.GetKeyDown(_keyCode) && canPressButton)
            _interactable.Interact();
    }
    private void OnTriggerExit(Collider other)
    {
        _currentInteractGO = null;
        inCollider = false;
    }
}



