using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Interface for UI controllers
public interface IUIController
{
    void OpenUI(KeyCode keyCode);
    void CloseUI(KeyCode keyCode);
    KeyCode LocalKey { get; }
}

// Enum to represent UI action states (Open or Closed)
public enum InterfacesAction
{
    Open,
    Closed,
}

public class UserInterface : MonoBehaviour
{
    public KeyCode LocalKey { get; private set; }
    public static InterfacesAction CurrentAction { get; set; } = InterfacesAction.Closed;

    private List<IUIController> uiControllers = new List<IUIController>();
    public GameObject currentGO;
    private void Awake()
    {
        LocalKey = ControllerMenuSettings.InterfacesKey;
        AddToArreyOfInterfaces();
    }

    private void AddToArreyOfInterfaces()
    {
        // Find all objects in the scene that implement the IUIController interface
        var foundUIControllers = FindObjectsOfType<MonoBehaviour>().OfType<IUIController>();

        // Add the found UI controllers to the list
        uiControllers.AddRange(foundUIControllers);
    }

    public void HandleInterfaceInput(KeyCode inputKey)
    {
        foreach (var currentUI in uiControllers)
        {
            currentGO = ((MonoBehaviour)currentUI).gameObject;
            ToggleMethod(currentUI, inputKey);
        }
    }

    private void ToggleMethod(IUIController currentUI, KeyCode inputKey)
    {
        if (inputKey == currentUI.LocalKey)
        {
            switch (CurrentAction)
            {
                case InterfacesAction.Closed:
                    currentUI.OpenUI(inputKey);
                    CurrentAction = InterfacesAction.Open;
                    break;
                case InterfacesAction.Open:
                    currentUI.CloseUI(inputKey);
                    CurrentAction = InterfacesAction.Closed;
                    break;
            }
        }
    }

    public virtual void CloseUI(KeyCode keyCode)
    {
        Debug.Log("Close " + name);
        //if (keyCode == LocalKey && UserInterface.CurrentAction == InterfacesAction.Open)
    }

    public virtual void OpenUI(KeyCode keyCode)
    {
        Debug.Log("Open " + name);
        //if (keyCode == LocalKey && UserInterface.CurrentAction == InterfacesAction.Closed)

    }
}
