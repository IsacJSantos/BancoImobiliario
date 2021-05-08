using UnityEngine;

[CreateAssetMenu(fileName = "playerSkin",menuName = "Player/Skin")]
public class PLayerContainer : ScriptableObject
{
    public PlayerData[] playerData;
}
[System.Serializable]
public class PlayerData
{
    public GameObject playerPrefab;
    public Sprite skinIcon;
}
