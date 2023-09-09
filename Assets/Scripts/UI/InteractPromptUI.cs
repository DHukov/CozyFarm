using TMPro;
using UnityEngine;

public enum ActiveButton
{
    Realised,
    Pressed
}
public class InteractPromptUI : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private TMP_Text _text;

    private void Start()
    {
        if (_canvas == null)
            _canvas = GetComponentInChildren<Canvas>();
        else
            return;
        _text = GetComponentInChildren<TMP_Text>();
        _canvas.gameObject.SetActive(false);
    }
    public void Displayed()
    {
        _canvas.gameObject.SetActive(true);
    }
    public void Closed()
    {
        _canvas.gameObject.SetActive(false);
    }
    //Changer button color when realise or press button
    public void UIButtonEffect(ActiveButton ab)
    {
        Color32 color = _text.color;
        switch (ab)
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

