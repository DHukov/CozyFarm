using UnityEngine;

public class SettingsMenu : WindowBase, IWindow, IKeyBinded
{
    public static SettingsMenu Instance;

    public KeyCode LocalKey { get => PlayerGameBinds.SettingsMenuKey; }

    public override void CloseUI(GameObject gameObject)
    {

        Time.timeScale = +1;
        base.CloseUI(this.gameObject);
    }

    public override void OpenUI(GameObject gameObject)
    {
        Time.timeScale = +0;
        base.OpenUI(this.gameObject);   
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(Instance);
    }
}
