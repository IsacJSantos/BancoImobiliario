using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnActions : MonoBehaviour
{
    public bool IsFinish { get; private set; }
    [SerializeField]
    Dice _dice;

    Piece _piece;
    private void Start()
    {
        _dice.IsFinish += _dice_IsFinish;
    }

    public void InitActions(Piece piece)
    {
        _piece = piece;
        SortANumber();
    }

    // Events
    private void _dice_IsFinish(object sender, System.EventArgs e)
    {
        MovePiece(_dice.SortValue);
    }

    void MoveCompleted()
    {
        Debug.Log("terminou");
        // CheckPosition();
    }

    void CheckPosCompleted()
    {
        Debug.Log("terminou");
    }

    //--------

    void SortANumber()
    {
        _dice.RollDice();
    }

    void MovePiece(int movements)
    {
        _piece.MoveRequest(movements);
    }

    void CheckPosition()
    {

    }


}
