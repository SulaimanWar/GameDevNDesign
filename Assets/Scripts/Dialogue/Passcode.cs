using UnityEngine;
using TMPro;

public class Passcode : MonoBehaviour
{
    public TextMeshProUGUI inputText;

    public string GetInput()
    {
        return inputText.text;
    }
}
