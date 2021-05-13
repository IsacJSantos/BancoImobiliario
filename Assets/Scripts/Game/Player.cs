using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Piece Piece;
    public string playerName;
    public int Id;
    public List<Place> Properties = new List<Place>();

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
        if (id != this.Id)
            return;

        Piece.Move(movements,id);
    }
}
