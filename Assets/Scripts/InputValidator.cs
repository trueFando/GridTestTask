using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputValidator : MonoBehaviour
{
    public void ValidateInt(InputField inputField)
    {
        int value;
        if (!int.TryParse(inputField.text, out value))
            inputField.text = string.Empty;
        if (value <= 0)
            inputField.text = string.Empty;
    }
}
