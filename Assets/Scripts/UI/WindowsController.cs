using System.Collections.Generic;
using UnityEngine;

public interface IKeyBinded
{
    public KeyCode LocalKey { get; } // Get the key to control this UI.
}

public interface IInputable : IKeyBinded
{
    public void KeyInput(KeyCode keyCode);
}

public class WindowsController : MonoBehaviour, IInputable
{
    private Dictionary<KeyCode, IUIWindow> windowsDict = new Dictionary<KeyCode, IUIWindow>(); // Dictionary to map keys to UI controllers.

    private IUIWindow currentWindow = null; // The currently open UI controller.
    public KeyCode LocalKey { get; } // Get the key to control this UI.

    private void Start()
    {
        AddToDictionary(); // Find and initialize UI controllers.
    }

    private void AddToDictionary()
    {
        foreach (var currentUI in WindowBase.windowsList)
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

    private void ToggleWindow(IUIWindow window)
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
