using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask; // A LayerMask(s) for interactable objects
    public static Interactor instance; // A static instance of the Interactor.
    private IInteractable _interactable; // The interactable object currently in focus.
    private InteractPromptUI _promptUI; // The UI prompt for interaction.
    private Collider interactObjectCollider;
    public static bool PlayerInInteractField { get; private set; } // A flag indicating if the player is in the interaction field.

    private void Awake()
    {
        if (instance == null && gameObject.tag == "Player")
            instance = this; // Set the static instance to Player object.
        else
            Destroy(gameObject); // Destroy this object if another instance already exists.
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == ExtraMathFunction.IsPowerOfTwo(layerMask.value) && other != null)
        {
            interactObjectCollider = other;
            PlayerInInteractField = true; // Set the player in the interaction field.
            AnObjectAreInteractable(other); // Determine the type of object the player is interacting with.
        }
    }
    private bool AnObjectAreInteractable(Collider collider)
    {
        if (collider.GetComponent<InteractPromptUI>() != null && collider.gameObject.GetComponent<IInteractable>() != null)
        {
            // If the collider has both InteractPromptUI and IInteractable components, set them and display the UI prompt.
            _promptUI = collider.gameObject.GetComponent<InteractPromptUI>();
            _interactable = collider.gameObject.GetComponent<IInteractable>();
            _promptUI.Displayed();
            return true;
        }
        else
        {
            Debug.Log("Component InteractPromptUI or IInteractable not are instance of an object");
            return false; // Log an error message if required components are not found and exit early.
        }
    }

    private bool AnObjectHaveInteractComponents()
    {
        if (interactObjectCollider != null)
            return AnObjectAreInteractable(interactObjectCollider);
        return false;
    }

    public void CanInteract()
    {
        if (AnObjectHaveInteractComponents() && PlayerInInteractField)
            _interactable.Interact();
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerInInteractField = false; // Set the player out of the interaction field.
        if (_promptUI != null)
            _promptUI.Closed(); // Close the UI prompt if it exists.
        _interactable = null;
        _promptUI = null; // Reset references when the player exits the interaction field.
    }
}