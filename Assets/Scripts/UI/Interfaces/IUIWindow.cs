using UnityEngine;

public interface IUIWindow
{
    void OpenUI(GameObject gameObject); // Method to open the UI associated with this controller.
    void CloseUI(GameObject gameObject); // Method to close the UI associated with this controller.
}
