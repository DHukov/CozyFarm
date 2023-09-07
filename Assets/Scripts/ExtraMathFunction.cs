using UnityEngine;

public class ExtraMathFunction
{
    private static int _layerMaskIndex;
    public static int IsPowerOfTwo(int layerMaskValue)
    {
        for (int i = 0; i <= layerMaskValue; i++)
            if (Mathf.Pow(2, i) == layerMaskValue)
                _layerMaskIndex = i;
        return _layerMaskIndex;
    }
}