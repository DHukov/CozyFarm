using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public interface IKeyBinded
{
    KeyCode LocalKey { get; } // Get the key to control this UI.

}
public interface IWindow
{
    void OpenUI(GameObject gameObject); // Method to open the UI associated with this controller.
    void CloseUI(GameObject gameObject); // Method to close the UI associated with this controller.
}

public class WindowsController : MonoBehaviour
{
    public static WindowsController Instance; // Static instance of the WindowsController.

    private IWindow currentWindow = null; // The currently open UI controller.

    private List<IWindow> windowsList = new List<IWindow>(); // List of available UI controllers.
    private Dictionary<KeyCode, IWindow> windowsDict = new Dictionary<KeyCode, IWindow>(); // Dictionary to map keys to UI controllers.

    private void Awake()
    {
        if (Instance == null)
            Instance = this; // Set the static instance to this object.
        else
            Destroy(Instance); // Destroy this object if another instance already exists.
    }
    private void Start()
    {
        FindAndAddToDictionaryByWindow(); // Find and initialize UI controllers.
    }

    private void FindAndAddToDictionaryByWindow()
    {
        var foundUIControllers = FindObjectsOfType<MonoBehaviour>().OfType<IWindow>(); // Find all objects implementing IUIController.
        windowsList.AddRange(foundUIControllers); // Add them to the windowsList.

        foreach (var currentUI in windowsList)
        {
            windowsDict.Add(((MonoBehaviour)currentUI).GetComponent<IKeyBinded>().LocalKey, currentUI); // Map the key to the UI controller.
            currentUI.CloseUI(((MonoBehaviour)currentUI).gameObject);
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

    private void ToggleWindow(IWindow window)
    {
        if (currentWindow != null)
            currentWindow.CloseUI(((MonoBehaviour)currentWindow).gameObject); // Close the currently open UI.

        if (currentWindow == window)
            currentWindow = null; // If the same UI is clicked again, close it.
        else
        {
            currentWindow = window;
            currentWindow.OpenUI(((MonoBehaviour)currentWindow).gameObject); // Open the selected UI.
        }
    }

}
