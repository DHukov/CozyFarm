using UnityEngine;

public class SettingsMenu : UserInterface, IUIController
{
    public static SettingsMenu instance;

    public new KeyCode LocalKey { get => ControllerMenuSettings.SettingsMenuKey; }

    private void Start()
    {
        gameObject.SetActive(false);
    }
    public override void CloseUI(KeyCode keyCode)
    {
        gameObject.SetActive(false);
        //gameObject.SetActive(true);
        base.CloseUI(LocalKey);

    }

    public override void OpenUI(KeyCode keyCode)
    {
        gameObject.SetActive(true);
        base.OpenUI(LocalKey);
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(instance);
    }
}
