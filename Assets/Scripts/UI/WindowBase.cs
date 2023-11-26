using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Android;

public abstract class WindowBase : MonoBehaviour, IUIWindow
{
    public readonly static List<IUIWindow> windowsList = new List<IUIWindow>();

    /// <summary>
    /// Add this GO to Windows UI list 
    /// </summary>
    /// <param name="currentWindow"></param>
    /// <returns></returns>
    public IUIWindow InitToList(IUIWindow currentWindow)
    {
        if (!windowsList.Contains(currentWindow))
        {
                windowsList.Add(currentWindow);
                Debug.Log($"{currentWindow} added");
        }
        return currentWindow;
    }
    public virtual void CloseUI(GameObject gameObject)
    {
        gameObject.SetActive(false);
        Debug.Log($"{gameObject.name} {gameObject.activeSelf}");
    }

    public virtual void OpenUI(GameObject gameObject)
    {
        gameObject.SetActive(true);
        Debug.Log($"{gameObject.name} {gameObject.activeSelf}");
    }
}
