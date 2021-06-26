using UnityEngine;
using UnityEngine.UI;

public class Turn : MonoBehaviour
{
    public PlaceChecker PlaceChecker { get; private set; }
  
    [SerializeField] Dice _dice;

    Player _player;
    UIController _uIController;

    private void Awake()
    {
        Events.OnDiceFinish += DiceRollerFinish;
        Events.OnInitTurn += InitTurn;
        Events.OnPlayerFinishMove += MoveFinish;
        Events.OnCheckPlaceFinish += CheckFinish;
    }
    private void Start()
    {
        PlaceChecker = GetComponent<PlaceChecker>();
        _uIController = GameObject.FindGameObjectWithTag("UiController").GetComponent<UIController>();
    }
    private void OnDestroy()
    {
        Events.OnDiceFinish -= DiceRollerFinish;
        Events.OnInitTurn -= InitTurn;
        Events.OnPlayerFinishMove -= MoveFinish;
        Events.OnCheckPlaceFinish -= CheckFinish;
    }

    void InitTurn(Player player)
    {
        _player = player;
        InitActions();
    }
    public void InitActions()
    {
        Events.OnRollDice?.Invoke();
    }

    void DiceRollerFinish(int value)
    {
        MovePiece(value);
    }
    public void MoveFinish()
    {
        CheckPlaceInfos();
    }

    public void CheckFinish()
    {
        Events.OnFinishTurn?.Invoke();
    }

    void MovePiece(int movements)
    {
        Events.OnPlayerMove?.Invoke(_player.id, movements);
    }

    void CheckPlaceInfos()
    {
        Events.OnCheckPlace?.Invoke(_player);
    }
}
