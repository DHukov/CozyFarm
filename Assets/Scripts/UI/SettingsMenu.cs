using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField]
    public static KeyCode interactKey
    {
        get { return KeyCode.E; }
        private set { }
    }
    public static KeyCode settingsMenu
    {
        get { return KeyCode.E; }
        private set { }
    }
    public static KeyCode storeOpen
    {
        get { return KeyCode.P; }
        private set { }
    }

    public bool Closed()
    {
        gameObject.SetActive(false);
        return false;

    }

    public bool Displayed()
    {
        gameObject.SetActive(true);
        return true;

    }

    public void UIKeyBind(KeyCode buttonState)
    {

    }

    void Start()
    {

    }

    void Update()
    {

    }
}
