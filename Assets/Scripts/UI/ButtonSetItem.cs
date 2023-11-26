using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSetItem : MonoBehaviour
{
    private StoreManager storeManager;
    private FarmObjectData storeItem;
    private Button button;

    private void Start()
    {
        storeManager = GetComponentInParent<StoreManager>();
        button = GetComponent<Button>();
        storeItem = gameObject.GetComponentInParent<StoreItem>().GetFarmObjectData();
        button.onClick.AddListener(delegate { storeManager.BuyObject(storeItem); });

    }
}
