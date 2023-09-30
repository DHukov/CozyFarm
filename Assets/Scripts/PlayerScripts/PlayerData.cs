using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "ScriptableObject Player")]
public class PlayerData : ScriptableObject
{
    public Vector3 playerPosition;
    public string playerName;
    public float playerSpeed = 10;
    public float playerRotationSpeed = 0.1f;
    [field: SerializeField] public int playerMoney { get; private set; }

    public int SetAmountMoney(int money) => playerMoney += money;
}
