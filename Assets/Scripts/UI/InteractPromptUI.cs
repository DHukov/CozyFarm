using TMPro;
using UnityEngine;
public class InteractPromptUI : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
     private TMP_Text KeyCodeText;

    private void Start()
    {

        KeyCodeText = GetComponentInChildren<TMP_Text>();
        canvas = GetComponentInChildren<Canvas>();
        canvas.gameObject.SetActive(false);
    }
    public bool Displayed()
    {
        if (canvas != null)
            canvas.gameObject.SetActive(true);
        return true;
    }

    public bool Closed()
    {
        if (canvas != null)
            canvas.gameObject.SetActive(false);
        return false;
    }

    public void ButtonActive()
    {

    }
    public void ButtonInactive()
    {

    }
    //Change button color when realise or press key
    //public void UIButtonState(ActiveButton activeButton)
    //{
    //    Color32 color = _KeyCodeText.color;
    //    switch (activeButton)
    //    {
    //        case ActiveButton.Pressed:
    //            color.a = 160;
    //            _KeyCodeText.color = color;
    //            break;
    //        case ActiveButton.Realised:
    //            color.a = 200;
    //            _KeyCodeText.color = color;
    //            break;
    //        default:
    //            Debug.Log("default");
    //            color.a = 200;
    //            _KeyCodeText.color = color;
    //            break;
    //    }
    //}
}
