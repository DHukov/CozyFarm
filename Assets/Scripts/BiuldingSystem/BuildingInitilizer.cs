using System.Threading;
using UnityEngine;

public class BuildingInitilizer : BaseObject, IPlacement
{
    [SerializeField] private GameObject buildArea;
    private Vector3 currentObject;

    private void Start()
    {
        buildArea.SetActive(false);
        currentObject = transform.position;


    }
    private void Update()
    {
        ShowBuildArea();
    }

    private void ShowBuildArea()
    {
        if (Interactor.currentInteractObject == gameObject.GetComponent<Collider>())
            buildArea.SetActive(true);
        else
            buildArea.SetActive(false);
    }

    public override void Interact()
    {
        if (PlayerManager.playerInventory.Count == 0)
        {
            Debug.Log("No purchased items");
        }
        else
        {
            for (int i = 0; i < PlayerManager.playerInventory.Count; i++)
                SetObjectPosition(PlayerManager.playerInventory[0], currentObject);

        }
    }

    public void SetObjectPosition(ObjectData objectData, Vector3 vector3)
    {
        Destroy(gameObject);
        Debug.Log("Warning");
        Instantiate(objectData.prefab, vector3, Quaternion.identity);
    }
}
