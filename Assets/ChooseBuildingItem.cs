using UnityEngine;
using UnityEngine.UI;


public class ChooseBuildingItem : MonoBehaviour
{
    private FarmObjectData storeItem;
    private Button button;
    [SerializeField]

    private void Start()
    {
        button = GetComponent<Button>();
        storeItem = gameObject.GetComponentInParent<StoreItem>().GetFarmObjectData();
        button.onClick.AddListener(delegate { PlayerData.SetItemLikeCurrent(storeItem); });

    }
}
