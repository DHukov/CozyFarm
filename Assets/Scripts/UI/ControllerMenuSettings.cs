using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ControllerMenuSettings : MonoBehaviour
{
    private UnityEvent ChangeKey;
    private KeyCode changeInputKey;

    public void SetKey()
    {
        //SettingsDictionary[changeSettingsAction] = changeInputKey;
        //foreach (var item in SettingsDictionary)
        //    Debug.Log(item);
    }

    public static KeyCode InteractKey
    {
        get { return KeyCode.E; }
        private set { }
    }
    public static KeyCode DefaultKey
    {
        get { return KeyCode.None; }
        private set { }
    }
    public static KeyCode InterfacesKey
    {
        get { return KeyCode.L; }
        private set { }
    }
    public static KeyCode SettingsMenuKey
    {
        get { return KeyCode.Escape; }
        private set { }
    }
    public static KeyCode StoreKey
    {
        get { return KeyCode.P; }
        private set { }
    }
}