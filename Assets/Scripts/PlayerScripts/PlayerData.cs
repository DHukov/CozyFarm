using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Object", menuName = "ScriptableObject Player")]
public class PlayerData : ScriptableObject
{
    public Vector3 playerPosition;
    public string playerName;
    public float playerSpeed = 10;
    public float playerRotationSpeed = 0.1f;
    [field: SerializeField] public int playerMoney { get; private set; }

    public int DecreaseMoney(int money) => playerMoney -= money;
    public int IncreaseMoney(int money) => playerMoney += money;
    public bool CanAfford(int cost) => playerMoney >= cost;

    private static List<FarmObjectData> playerItems = new();

    public void AddItem(FarmObjectData itemToAdd) => playerItems.Add(itemToAdd);
    public void RemoveItem(FarmObjectData itemToAdd) => playerItems.Remove(itemToAdd);

    public static FarmObjectData CurrentInventoryItem
    {
        get
        {
            if (playerItems.Count > 0)
            {
                return playerItems[playerItems.Count - 1];
            }
            return new FarmObjectData();
        }
    }
    private static void Swap<T>(IList<T> list, int indexA, int indexB)
    {
        T tmp = list[indexA];
        list[indexA] = list[indexB];
        list[indexB] = tmp;
    }

    public static void SetItemLikeCurrent(FarmObjectData current)
    {
        for (int i = 0; i < playerItems.Count; i++)
        {
            if (playerItems[i] == current)
            {
                Swap(playerItems, i, playerItems.Count-1);
                Debug.Log($"{playerItems[playerItems.Count-1]} + ready to build");
            }
        }
    }
}
