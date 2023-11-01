using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public interface IKeyBinded
{
    public KeyCode LocalKey { get; } // Get the key to control this UI.
}

public interface IInputable : IKeyBinded
{
    public void KeyInput(KeyCode keyCode);
}
public interface IWindow
{
    void OpenUI(GameObject gameObject); // Method to open the UI associated with this controller.
    void CloseUI(GameObject gameObject); // Method to close the UI associated with this controller.
}

public class WindowsController : MonoBehaviour, IInputable
{
    public static WindowsController Instance; // Static instance of the WindowsController.

    private IWindow currentWindow = null; // The currently open UI controller.

    private List<IWindow> windowsList = new List<IWindow>(); // List of available UI controllers.
    private Dictionary<KeyCode, IWindow> windowsDict = new Dictionary<KeyCode, IWindow>(); // Dictionary to map keys to UI controllers.

    public KeyCode LocalKey => throw new System.NotImplementedException();

    private void Awake()
    {
        if (Instance == null)
            Instance = this; // Set the static instance to this object.
        else
            Destroy(Instance); // Destroy this object if another instance already exists.
    }
    private void Start()
    {
        FindByIWindowAddToDictionary(); // Find and initialize UI controllers.
    }

    private void FindByIWindowAddToDictionary()
    {
        var foundUIControllers = FindObjectsOfType<WindowBase>().OfType<IWindow>(); // Find all objects implementing IUIController.
        windowsList.AddRange(foundUIControllers); // Add them to the windowsList.

        foreach (var currentUI in windowsList)
        {
            windowsDict.Add(((WindowBase)currentUI).GetComponent<IKeyBinded>().LocalKey, currentUI); // Map the key to the UI controller.
            currentUI.CloseUI(((WindowBase)currentUI).gameObject);
        }
    }

    public void KeyInput(KeyCode keyCode)
    {
        foreach (var item in windowsDict)
        {
            if (item.Key == keyCode)
                ToggleWindow(item.Value); // Toggle the specified UI using the key.
        }
    }

    private void ToggleWindow(IWindow window)
    {
        if (currentWindow != null)
            currentWindow.CloseUI(((WindowBase)currentWindow).gameObject); // Close the currently open UI.

        if (currentWindow == window)
            currentWindow = null; // If the same UI is clicked again, close it.
        else
        {
            currentWindow = window;
            currentWindow.OpenUI(((WindowBase)currentWindow).gameObject); // Open the selected UI.
        }
    }
}
