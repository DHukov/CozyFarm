using System.Linq;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    public float HozirontalXInput() => Input.GetAxisRaw("Horizontal");
    public float VerticalYInput() => Input.GetAxisRaw("Vertical");

    public void HandlePlayerInput(KeyCode keyCode)
    {
        IInputable[] inputables = FindObjectsOfType<MonoBehaviour>().OfType<IInputable>().ToArray();

        foreach (var inputable in inputables)
            inputable.KeyInput(keyCode);
    }
}
