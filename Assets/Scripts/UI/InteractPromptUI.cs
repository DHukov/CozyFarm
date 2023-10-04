using TMPro;
using UnityEngine;
public class InteractPromptUI : MonoBehaviour
{
    private Canvas _canvas;
    private TMP_Text _KeyCodeText;

    private void Start()
    {

        _KeyCodeText = GetComponentInChildren<TMP_Text>();
        _canvas = GetComponentInChildren<Canvas>();
        _canvas.gameObject.SetActive(false);
    }
    public bool Displayed()
    {
        _canvas.gameObject.SetActive(true);
        return true;
    }

    public bool Closed()
    {
        _canvas.gameObject.SetActive(false);
        return false;
    }

    public void ButtonActive()
    {

    }
    public void ButtonInactive()
    {
        
    }
    //Change button color when realise or press key
    public void UIButtonState(ActiveButton activeButton)
    {
        Color32 color = _KeyCodeText.color;
        switch (activeButton)
        {
            case ActiveButton.Pressed:
                color.a = 160;
                _KeyCodeText.color = color;
                break;
            case ActiveButton.Realised:
                color.a = 200;
                _KeyCodeText.color = color;
                break;
            default:
                Debug.Log("default");
                color.a = 200;
                _KeyCodeText.color = color;
                break;
        }
    }
}
