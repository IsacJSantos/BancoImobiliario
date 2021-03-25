using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreInfoController : MonoBehaviour
{
    [SerializeField]
    Text _playerIdTxt,_pointsIdTxt;

    public void SetScoreInfo(int playerId) 
    {
        _playerIdTxt.text = playerId.ToString();
    }
    public Text GetPoinstTxt() 
    {
        return _pointsIdTxt;
    }
    public void SetPointsTxt(Text text) 
    {
        _pointsIdTxt = text;
    }
}
