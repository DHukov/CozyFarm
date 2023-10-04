using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private UserInterface userInterface;

    // List to store the player's inventory
    public List<ObjectData> playerInventory = new List<ObjectData>();

    // Singleton instance of PlayerManager
    public static PlayerManager Instance { get; private set; }

    private void Awake()
    {
        // Ensure there is only one instance of PlayerManager in the scene.
        if (playerData == null && Instance == null)
        {
            Instance = this;
            Debug.LogError("Player Data is not assigned in PlayerManager!");
        }
        else
        {
            Destroy(Instance);
        }
    }

    // Check if the player has enough money to afford a purchase.
    public bool CanAfford(int cost) => playerData.playerMoney >= cost;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        PlayerMovementInput();
        Debug.Log(UserInterface.CurrentAction);
    }

    private void PlayerMovementInput()
    {
        // Handle player movement based on input from arrow keys or WASD.
        float horizontal_X = Input.GetAxisRaw("Horizontal");
        float vertical_Z = Input.GetAxisRaw("Vertical");
        var moveDirection = new Vector3(horizontal_X, 0, vertical_Z).normalized;
        playerMovement.Movement(playerData.playerSpeed, playerData.playerRotationSpeed, moveDirection);
    }

    private void PlayerInteractInput(KeyCode keyCode)
    {
        Interactor.instance.CanInteract();
        userInterface.HandleInterfaceInput(keyCode);
    }

    void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey && e.type == EventType.KeyUp)
            PlayerInteractInput(e.keyCode);
    }
}
