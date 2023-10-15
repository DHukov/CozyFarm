using UnityEngine;

public class Interactor : MonoBehaviour, IKeyBinded
{
    [SerializeField] private LayerMask layerMask; // A LayerMask(s) for interactable objects
    public static Interactor Instance; // A static instance of the Interactor.
    private IInteractable interactable; // The interactable object currently in focus.
    private InteractPromptUI promptUI; // The UI prompt for interaction.
    public static Collider currentInteractObject { get; private set; }
    public static bool PlayerInInteractField { get; private set; } // A flag indicating if the player is in the interaction field.

    public KeyCode LocalKey => PlayerGameBinds.InteractKey;

    private void Awake()
    {
        if (Instance == null && gameObject.tag == "Player")
            Instance = this; // Set the static instance to Player object.
        else
            Destroy(gameObject); // Destroy this object if another instance already exists.
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == ExtraMathFunction.IsPowerOfTwo(layerMask.value) && other != null)
        {
            currentInteractObject = other;
            PlayerInInteractField = true; // Set the player in the interaction field.
            AnObjectAreInteractable(other); // Determine the type of object the player is interacting with.
        }
        else
            currentInteractObject = null;
    }
    private bool AnObjectAreInteractable(Collider collider)
    {
        if (collider.GetComponent<InteractPromptUI>() != null && collider.gameObject.GetComponent<IInteractable>() != null)
        {
            // If the collider has both InteractPromptUI and IInteractable components, set them and display the UI prompt.
            promptUI = collider.gameObject.GetComponent<InteractPromptUI>();
            interactable = collider.gameObject.GetComponent<IInteractable>();
            promptUI.Displayed();
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
        if (currentInteractObject != null)
            return AnObjectAreInteractable(currentInteractObject);
        return false;
    }

    public void CanInteract(KeyCode keyCode)
    {
        if (keyCode == LocalKey && PlayerInInteractField)
        {
            if (AnObjectHaveInteractComponents())
                interactable.Interact();
            else
            {
                if (promptUI != null)
                    promptUI.Closed();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerInInteractField = false; // Set the player out of the interaction field.
        if (promptUI != null)
        {
            promptUI.Closed(); // Close the UI prompt if it exists.
            promptUI = null; // Reset references when the player exits the interaction field.
        }
        interactable = null;
        currentInteractObject = null;

    }
}