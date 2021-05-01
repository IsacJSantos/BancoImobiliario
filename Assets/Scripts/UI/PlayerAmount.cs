using UnityEngine;
using UnityEngine.UI;

public class PlayerAmount : MonoBehaviour
{
    [SerializeField] InputField inputField;

    public void ButtonSelect()
    {     
        Events.OnGeneratePlayerPanel?.Invoke(int.Parse(inputField.text));
    }
}
