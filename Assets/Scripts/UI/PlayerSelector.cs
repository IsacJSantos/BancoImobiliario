using UnityEngine;
using UnityEngine.UI;

public class PlayerSelector : MonoBehaviour
{
    public int atualSkinIndex = 0;

    [SerializeField] string playerSkinPath;
    [SerializeField] Image selectedPlayreSkinImg;
   

    private void Start()
    {
        selectedPlayreSkinImg.sprite = Resources.Load<SkinContainer>(playerSkinPath).playerData[0].skinIcon;

       /* foreach (var item in Resources.Load<PLayerContainer>(playerSkinPath).playerData)
        {
            Debug.Log(item.playerPrefab.GetComponent<Player>().playerName);
        }*/
    }

    public void ButtonSelectSkin(int index)  // -1 or 1
    {
        if (index != -1 && index != 1) 
        {
            Debug.LogError("Button index is invalid. It's must be -1 or 1");
            return;
        }

        atualSkinIndex += index;
     
        if (atualSkinIndex >= 0 && atualSkinIndex < Resources.Load<SkinContainer>(playerSkinPath).playerData.Length) 
        {
            selectedPlayreSkinImg.sprite = Resources.Load<SkinContainer>(playerSkinPath).playerData[atualSkinIndex].skinIcon;
        }
        else if (atualSkinIndex < 0)
        {
            atualSkinIndex = Resources.Load<SkinContainer>(playerSkinPath).playerData.Length - 1;
            selectedPlayreSkinImg.sprite = Resources.Load<SkinContainer>(playerSkinPath).playerData[atualSkinIndex].skinIcon;          
        }
        else
        {           
            atualSkinIndex = 0;
            selectedPlayreSkinImg.sprite = Resources.Load<SkinContainer>(playerSkinPath).playerData[0].skinIcon;
        }

    }

}
