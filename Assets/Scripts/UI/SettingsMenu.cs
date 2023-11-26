using UnityEngine;

public class SettingsMenu : WindowBase, IUIWindow, IKeyBinded
{

    public KeyCode LocalKey { get => PlayerGameBinds.SettingsMenuKey; }
    private void Awake()
    {
        InitToList(this);
    }
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

}
