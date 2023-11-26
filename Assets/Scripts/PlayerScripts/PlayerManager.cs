using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerData playerData; // Reference to the player's data.
    [SerializeField] private PlayerMovement playerMovement; // Reference to the player's movement script.
    [SerializeField] private PlayerInputManager playerInputManager;

    private void Awake()
    {
    }

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
