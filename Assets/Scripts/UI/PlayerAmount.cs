using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerAmount : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] Canvas canvas;
    public void ButtonSelect()
    {     
        Events.OnGeneratePlayerPanel?.Invoke(int.Parse(inputField.text));
        canvas.enabled = false;

    }
}
