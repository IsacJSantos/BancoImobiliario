using UnityEngine;
using System;

public class TurnActions : MonoBehaviour
{
    public event EventHandler IsFinish;
    [SerializeField]
    Dice _dice;

    Player _player;
    PlaceChecker _placeChecker;

    private void Start()
    {
        _placeChecker = GetComponent<PlaceChecker>();

        _dice.IsFinish += _dice_IsFinish;
        _placeChecker.IsFinish += _placeChecker_IsFinish;
    }


    public void InitActions(Player player)
    {
        _player = player;
        _player.Piece.IsFinish += _piece_IsFinish;
        SortANumber();
    }

    // Events
    private void _dice_IsFinish(object sender, System.EventArgs e)
    {
        MovePiece(_dice.SortValue);
    }
    private void _piece_IsFinish(object sender, System.EventArgs e)
    {
        CheckPlaceInfos();
    }
    private void _placeChecker_IsFinish(object sender, System.EventArgs e)
    {
        IsFinish?.Invoke(this, EventArgs.Empty);
    }
    //--------

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
        _placeChecker.CheckPlace(_player);
    }


}
