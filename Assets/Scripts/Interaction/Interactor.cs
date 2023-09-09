using UnityEngine;

public class Interactor : MonoBehaviour
{
    public static Interactor Instance;
    private KeyCode _keyCode = SettingsMenu.interactKey;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private IInteractable _interactable;
    [SerializeField] private InteractPromptUI _propmtpUI;
    private bool playerInInteractField;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(gameObject);
    }
    private void Update()
    {
        PlayerInteract();
    }

    //check collided object for UI and IInteractable
    private void OnTriggerEnter(Collider other)
    {
        _interactable = other.gameObject.GetComponent(typeof(IInteractable)) as IInteractable;
        _propmtpUI = other.gameObject.GetComponent(typeof(InteractPromptUI)) as InteractPromptUI;
        if (_propmtpUI != null)
            _propmtpUI.Displayed();
        else
            return;
        if (_interactable != null)
            playerInInteractField = true;
        else
            return;
    }
    //use key for interact and do something effect
    private void PlayerInteract()
    {
        if (Input.GetKeyDown(_keyCode) && playerInInteractField)
        {
            Debug.Log("Pressed");
            _propmtpUI.UIButtonEffect(ActiveButton.Pressed);
            _interactable.Interact();

        }
        if (Input.GetKeyUp(_keyCode) || !playerInInteractField)
            if (_propmtpUI == null)
                return;
            _propmtpUI.UIButtonEffect(ActiveButton.Realised);
    }
    //player outside interact field cannot use things
    private void OnTriggerExit(Collider other)
    {
        playerInInteractField = false;
        _interactable = null;
        _propmtpUI.Closed();
    }
}



