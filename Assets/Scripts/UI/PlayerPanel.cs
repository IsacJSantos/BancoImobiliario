using UnityEngine;

public class PlayerPanel : MonoBehaviour
{
    [SerializeField] TMPro.TMP_InputField playerNameInput;
    [SerializeField] PlayerSelector playerSelector;
    public string Name
    {
        get
        {
            return playerNameInput.text;
        }
    }
    public int Skin
    {
        get
        {
            return playerSelector.atualSkinIndex;
        }
    }


}
