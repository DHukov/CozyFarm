using TMPro;
using UnityEngine;
public class InteractPromptUI : MonoBehaviour
{
    private Canvas _canvas;
    private TMP_Text _text;

    private void Start()
    {
        if (_canvas == null)
            _canvas = GetComponentInChildren<Canvas>();
        else
            return;
        _text = GetComponentInChildren<TMP_Text>();
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
    //Change button color when realise or press key
    public void UIButtonState(ActiveButton activeButton)
    {
        Color32 color = _text.color;
        switch (activeButton)
        {
            case ActiveButton.Pressed:
                color.a = 160;
                _text.color = color;
                break;
            case ActiveButton.Realised:
                color.a = 200;
                _text.color = color;
                break;
            default:
                Debug.Log("default");
                color.a = 200;
                _text.color = color;
                break;
        }
    }
}
