using UnityEngine;

[CreateAssetMenu(fileName = "playerSkin",menuName = "Player/Skin")]
public class SkinContainer : ScriptableObject
{
    public SkinData[] playerData;
}
