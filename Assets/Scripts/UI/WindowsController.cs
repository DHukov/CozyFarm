using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public interface IKeyBinded
{
    KeyCode LocalKey { get; } // Get the key to control this UI.

}
public interface IUIController : IKeyBinded
{
    void OpenUI(); // Method to open the UI associated with this controller.
    void CloseUI(); // Method to close the UI associated with this controller.
}

public class WindowsController : MonoBehaviour
{
    public static WindowsController Instance; // Static instance of the WindowsController.

    public KeyCode LocalKey { get; private set; } // Get the key to open/close UIs.
    private IUIController currentWindow = null; // The currently open UI controller.

    private List<IUIController> windowsList = new List<IUIController>(); // List of available UI controllers.
    private Dictionary<KeyCode, IUIController> windowsDict = new Dictionary<KeyCode, IUIController>(); // Dictionary to map keys to UI controllers.

    private void Awake()
    {
        if (Instance == null)
            Instance = this; // Set the static instance to this object.
        else
            Destroy(Instance); // Destroy this object if another instance already exists.

        LocalKey = PlayerGameBinds.InterfacesKey; // Set the key for opening/closing UIs.
        FindAndAddToDictionaryByUI(); // Find and initialize UI controllers.
    }

    private void FindAndAddToDictionaryByUI()
    {
        var foundUIControllers = FindObjectsOfType<MonoBehaviour>().OfType<IUIController>(); // Find all objects implementing IUIController.
        windowsList.AddRange(foundUIControllers); // Add them to the windowsList.

        foreach (var currentUI in windowsList)
        {
            windowsDict.Add(currentUI.LocalKey, currentUI); // Map the key to the UI controller.
            ((MonoBehaviour)currentUI).gameObject.SetActive(false); // Deactivate the UI object.
        }
    }

    public void WindowsKeyController(KeyCode key)
    {
        foreach (var item in windowsDict)
        {
            if (item.Key == key)
                ToggleWindow(item.Value); // Toggle the specified UI using the key.
        }
    }

    private void ToggleWindow(IUIController window)
    {
        if (currentWindow != null)
            currentWindow.CloseUI(); // Close the currently open UI.

        if (currentWindow == window)
            currentWindow = null; // If the same UI is clicked again, close it.
        else
        {
            currentWindow = window;
            currentWindow.OpenUI(); // Open the selected UI.
        }
    }
}
