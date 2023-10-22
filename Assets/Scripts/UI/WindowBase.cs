using UnityEngine;

public abstract class WindowBase : MonoBehaviour, IWindow
{
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
