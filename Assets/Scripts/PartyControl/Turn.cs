using UnityEngine;
using UnityEngine.UI;

public class Turn : MonoBehaviour
{
    public PlaceChecker PlaceChecker { get; private set; }

    [SerializeField]
    Party _party;

    Dice _dice;
    Player _player;
    UIController _uIController;
    private void Start()
    {
        _player = GetComponent<Player>();
        _dice = GetComponent<Dice>();
        PlaceChecker = GetComponent<PlaceChecker>();
        _uIController = GameObject.FindGameObjectWithTag("UiController").GetComponent<UIController>();
    }

    public void InitTurn() 
    {
        InitActions();
    }
    public void InitActions()
    {
        _dice.RollDice();
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

    void MovePiece(int movements)
    {
        _player.Piece.MoveRequest(movements);
    }

    void CheckPlaceInfos()
    {
        PlaceChecker.CheckPlace();
    }
}
