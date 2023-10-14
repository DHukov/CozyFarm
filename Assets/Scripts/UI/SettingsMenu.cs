using UnityEngine;

public class SettingsMenu : MonoBehaviour, IUIController
{
    public static SettingsMenu instance;

    public KeyCode LocalKey { get => PlayerGameBinds.SettingsMenuKey; }

    public void CloseUI()
    {
        gameObject.SetActive(false);
        Time.timeScale = +1;
    }

    public void OpenUI()
    {
        gameObject.SetActive(true);
        Time.timeScale = +0;
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(instance);
    }
}
