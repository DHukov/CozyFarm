using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerData playerData; // Reference to the player's data.
    [SerializeField] private PlayerMovement playerMovement; // Reference to the player's movement script.
    public static PlayerManager Instance; // Static instance of the PlayerManager.
    [SerializeField] private PlayerInputManager playerInputManager;
    [SerializeField] static public List<ObjectData> playerInventory = new List<ObjectData>();

    private void Awake()
    {
        // Ensure there is only one instance of PlayerManager in the scene.
        if (Instance == null)
            Instance = this; // Set the static instance to this object.
        else
            Destroy(Instance); // Destroy this object if another instance already exists.
    }
    public bool CanAfford(int cost) => playerData.playerMoney >= cost;

    private void Start()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
        playerMovement = GetComponent<PlayerMovement>(); // Get the PlayerMovement component.
    }

    private void Update()
    {
        playerMovement.Movement(playerData.playerSpeed, playerData.playerRotationSpeed);
    }
    void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey && e.type == EventType.KeyUp)
            playerInputManager.HandlePlayerInput(e.keyCode); // Handle key events for player interactions.
    }
}
