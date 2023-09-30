using UnityEngine;


public class FarmObject : BaseObject
{
    [SerializeField] private BaseObject  itemObject;
    public override void Interact()
    {
        base.Interact();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            //DestroyObject();
        }
    }

}
