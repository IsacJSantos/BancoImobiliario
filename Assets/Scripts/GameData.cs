using UnityEngine;

public class GameData : MonoBehaviour
{
    
}
[System.Serializable]
public class SkinData
{
    public GameObject playerPrefab;
    public Sprite skinIcon;
}
[System.Serializable]
public class PlayerData
{
    public string playerName;
    public int id;
    public int skinId;
}
