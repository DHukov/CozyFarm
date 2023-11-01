using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    private Image buttonImage;
    private Color defaultColor;
    [SerializeField] private Color SelectButtonColor;

    private void Start()
    {
        buttonImage = GetComponent<Image>();
        defaultColor = buttonImage.color;
    }
    public void SetSelectedButtonColor()
    {
        buttonImage.color = SelectButtonColor;
    }
    public void ClearCollorButton()
    {
        buttonImage.color = defaultColor;
    }

}
