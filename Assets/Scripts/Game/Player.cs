using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Piece piece;
    public string playerName;
    public int id;
    public List<Place> properties = new List<Place>();

    [SerializeField]
    float _points;

    PlayerScoreInfoController _playerScoreInfo;

    private void Awake()
    {
        Events.OnPlayerMove += MoveRequest;       
    }

    private void OnDestroy()
    {
        Events.OnPlayerMove -= MoveRequest;
    }
    public void SetPlayerScoreInfo(PlayerScoreInfoController playerScoreInfo) 
    {
        _playerScoreInfo = playerScoreInfo;
    }
    
    public void SetView(PlayerData _playerData,Piece _piece) 
    {
        piece = _piece;
        playerName = _playerData.playerName;
        id = _playerData.id;
    }

    public PlayerScoreInfoController GetPlayerScoreInfo()
    {
        return _playerScoreInfo;
    }

    public float GetPoints()
    {
        return _points;
    }
    public void SetPoints(float points)
    {
        _points = points;
        _playerScoreInfo.GetPoinstTxt().text = _points.ToString();
    }
    public void SetPointTxt(Text text)
    {
        _playerScoreInfo.SetPointsTxt(text);
    }

    public void MoveRequest(int id,int movements) 
    {
        if (id != this.id)
            return;

        piece.Move(movements,id);
    }
}
