using UnityEngine;
using System;

public class Turn : MonoBehaviour
{
    public PlaceChecker PlaceChecker { get; private set; }

    [SerializeField]
    Party _party;

    Dice _dice;
    Player _player;
    private void Start()
    {
        _player = GetComponent<Player>();
        _dice = GetComponent<Dice>();
        PlaceChecker = GetComponent<PlaceChecker>();

      /*  _dice.IsFinish += _dice_IsFinish;
        _player.Piece.IsFinish += _piece_IsFinish;
        _placeChecker.IsFinish += _placeChecker_IsFinish;*/
    }

    public void InitTurn() 
    {
        InitActions();
    }
    public void DiceRollerFinish()
    {
        MovePiece(_dice.SortValue);
    }
    public void MoveFinish()
    {
        CheckPlaceInfos();
    }
    public void CheckFinish()
    {
        _party.FinishTurn();
    }

    public void InitActions()
    {
        SortANumber();
    }

    // Events
    /*private void _dice_IsFinish(object sender, System.EventArgs e)
    {
        MovePiece(_dice.SortValue);
    }
    private void _piece_IsFinish(object sender, System.EventArgs e)
    {
        print(_player.name + " is cheking place");
        CheckPlaceInfos();
    }
    private void _placeChecker_IsFinish(object sender, System.EventArgs e)
    {
        print("_placeChecker_IsFinish");
        
    }
    //--------
    */

    void SortANumber()
    {
        _dice.RollDice();
    }

    void MovePiece(int movements)
    {
        _player.Piece.MoveRequest(movements);
    }

    void CheckPlaceInfos()
    {
        PlaceChecker.CheckPlace();
    }
}
