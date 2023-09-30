using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerData playerData; 
    [SerializeField] private PlayerMovement playerMovement;
    public List<ObjectData> playerInventory = new List<ObjectData>(); 
    public static PlayerManager Instance; 

    private void Awake()
    {
        // Ensure there is only one instance of PlayerManager in the scene.
        if (playerData == null && Instance == null)
        {
            Instance = this;
            Debug.LogError("Player Data is not assigned in PlayerManager!");
            return;
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
        PlayerInteractInput(SettingsMenu.interactKey, Interactor.PlayerInInteractField); // Handle player interaction input.
    }

    void PlayerMovementInput()
    {
        // Handle player movement based on input from arrow keys or WASD.
        float horizontal_X = Input.GetAxisRaw("Horizontal");
        float vertical_Z = Input.GetAxisRaw("Vertical");
        var MovDirection = new Vector3(horizontal_X, 0, vertical_Z).normalized;
        playerMovement.Movement(playerData.playerSpeed, playerData.playerRotationSpeed, MovDirection);
    }

    void PlayerInteractInput(KeyCode keyCode, bool playerInInteractField)
    {
        // Handle player interaction input, starting or ending an interaction.
        if (Input.GetKeyDown(keyCode) && playerInInteractField)
            Interactor.instance.ButtonPressInteraction(); 
        if (Input.GetKeyUp(keyCode) || !playerInInteractField)
            Interactor.instance.ButtonRealiseInteraction(); 
    }
}
