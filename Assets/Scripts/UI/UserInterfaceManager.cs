using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class UserInterfaceManager : MonoBehaviour{
    private KeyCode _keyCode;
    Event e;
    void OnGUI()
    {
        e = Event.current;
        if (e.isKey)
        {
        }
    }
    private void Update()
    {
       
    }

    
}
