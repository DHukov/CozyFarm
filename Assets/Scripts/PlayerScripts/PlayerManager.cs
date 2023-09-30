using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerData playerData;
    public List<ObjectData> playerInventory = new List<ObjectData>();
    public static PlayerManager Instance;
    private void Awake()
    {
        if (playerData == null && Instance == null)
        {
            Instance = this;
            Debug.LogError("Player Data is not assigned in PlayerManager!");
            return;
        }
        else
            Destroy(Instance);
    }
    public bool CanAfford(int cost) => playerData.playerMoney >= cost;
}
