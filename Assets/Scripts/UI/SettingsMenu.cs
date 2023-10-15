using UnityEngine;

public class SettingsMenu : MonoBehaviour, IUIController
{
    public static SettingsMenu Instance;

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
        if (Instance == null)
            Instance = this;
        else
            Destroy(Instance);
    }
}
