using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "ScriptableObject Player")]
public class PlayerData : ScriptableObject
{
    public string playerName;
    [field: SerializeField] public int playerMoney { get; private set; }
    public int SetAmountMoney(int money) => playerMoney += money;
}
