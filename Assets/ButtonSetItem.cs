using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSetItem : MonoBehaviour
{
    [SerializeField] private StoreManager storeManager;
    [SerializeField] private FarmObjectData storeItem;
    [SerializeField] private Button button;

    private void Start()
    {
        storeManager = GetComponentInParent<StoreManager>();
        button = GetComponent<Button>();
        storeItem = gameObject.GetComponentInParent<StoreItemUI>().GetFarmObjectData();
        button.onClick.AddListener(delegate { storeManager.BuyObject(storeItem); });

    }
}
