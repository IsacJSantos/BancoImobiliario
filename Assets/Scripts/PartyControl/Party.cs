using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party : MonoBehaviour
{
  
    [SerializeField]
    Turn _turn;
    List<Player> _players = new List<Player>();

    void InitTurn() 
    {
        _turn.InitTurn();
    }
}
