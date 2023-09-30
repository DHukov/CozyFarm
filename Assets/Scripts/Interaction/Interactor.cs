using UnityEngine;

public class Interactor : MonoBehaviour
{
    private KeyCode _keyCode = SettingsMenu.interactKey; // The key code for interaction.
    private static Interactor instance; // A static instance of the Interactor.
    private IInteractable _interactable; // The interactable object currently in focus.
    private InteractPromptUI _promptUI; // The UI prompt for interaction.
    public static bool PlayerInInteractField { get; private set; } // A flag indicating if the player is in the interaction field.

    private void Awake()
    {
        if (instance == null && gameObject.tag == "Player")
            instance = this; // Set the static instance to Player object.
        else
            Destroy(gameObject); // Destroy this object if another instance already exists.
    }

    private void Update()
    {
        if (!PlayerInInteractField)
            return; // If the player is not in the interaction field, exit early.
        PlayerInteractInput(_keyCode, PlayerInInteractField); // Handle player interaction input.
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerInInteractField = true; // Set the player in the interaction field.
        SetTypeFromTheObject(other); // Determine the type of object the player is interacting with.
    }

    private void SetTypeFromTheObject(Collider collider)
    {
        if ((collider.GetComponent<InteractPromptUI>() != null) && (collider.gameObject.GetComponent<IInteractable>() != null))
        {
            // If the collider has both InteractPromptUI and IInteractable components, set them and display the UI prompt.
            _promptUI = collider.gameObject.GetComponent<InteractPromptUI>();
            _interactable = collider.gameObject.GetComponent<IInteractable>();
            _promptUI.Displayed();
        }
        else
        {
            Debug.Log("Component InteractPromptUI or IInteractable not are instance of an object");
            return; // Log an error message if required components are not found and exit early.
        }
    }

    // ToDo: Replace unput code to PlayerController

    private void PlayerInteractInput(KeyCode keyCode, bool playerInInteractField)
    {
        if (Input.GetKeyDown(keyCode) && playerInInteractField)
        {
            if (_interactable != null)
            {
                // If the interaction key is pressed and an interactable object exists, trigger the interaction.
                _promptUI.UIButtonState(ActiveButton.Pressed);
                _interactable.Interact();
            }
        }
        if (Input.GetKeyUp(keyCode) || !playerInInteractField)
        {
            if (_interactable != null)
                _promptUI.UIButtonState(ActiveButton.Realised); // Handle the release of the interaction key.
        }
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
