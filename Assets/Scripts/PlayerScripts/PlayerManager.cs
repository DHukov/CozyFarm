using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerData playerData; // Reference to the player's data.
    [SerializeField] private PlayerMovement playerMovement; // Reference to the player's movement script.
    public static PlayerManager Instance; // Static instance of the PlayerManager.

    // List to store the player's inventory
    [SerializeField] static public List<ObjectData> playerInventory = new List<ObjectData>();

    private void Awake()
    {
        // Ensure there is only one instance of PlayerManager in the scene.
        if (Instance == null)
            Instance = this; // Set the static instance to this object.
        else
            Destroy(Instance); // Destroy this object if another instance already exists.
    }

    // Check if the player has enough money to afford a purchase.
    public bool CanAfford(int cost) => playerData.playerMoney >= cost;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>(); // Get the PlayerMovement component.
    }

    private void Update()
    {
        PlayerMovementInput(); // Handle player movement.
    }

    private void PlayerMovementInput()
    {
        float horizontal_X = Input.GetAxisRaw("Horizontal");
        float vertical_Z = Input.GetAxisRaw("Vertical");
        var moveDirection = new Vector3(horizontal_X, 0, vertical_Z).normalized;
        playerMovement.Movement(playerData.playerSpeed, playerData.playerRotationSpeed, moveDirection);
    }

    private void PlayersInput(KeyCode keyCode)
    {
        Interactor.Instance.CanInteract(keyCode); // Trigger interactions using the Interactor.
        WindowsController.Instance.WindowsKeyController(keyCode); // Handle UI interactions using the WindowsController.
    }

    void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey && e.type == EventType.KeyUp)
            PlayersInput(e.keyCode); // Handle key events for player interactions.
    }
}
