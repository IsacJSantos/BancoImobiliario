using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    GameObject _buyPlaceUi, _paymentUi, _diceUi;
    [SerializeField]
    Text _placePriceTxt, _paymentTxt,_paymentPlayerTxt, _playerTurnTxt;

    Player _player;
    Dice _dice;
    private void Start()
    {
        _diceUi.SetActive(false);
        _buyPlaceUi.SetActive(false);
        _paymentUi.SetActive(false);
    }

    public void ShowDiceRoller(Dice dice) 
    {
        _dice = dice;
        SetDiceUiPlayerTxt();
        _diceUi.SetActive(true);
    }
    public void HideDiceRoller() 
    {
        _dice = null;
        _diceUi.SetActive(false);
    }

    public void RollDiceButton()// Will be called from button UI
    {
        if (_dice)
            _dice.Roll();
    }

    public void ShowShopMenu(Player player, float price)
    {
        _player = player;
        SetBuyPlaceUiText(price);
        _buyPlaceUi.SetActive(true);
    }
    public void HideShopMenu()
    {
        _buyPlaceUi.SetActive(false);
    }

    public void ShowPaymentMenu(Player player, float price)
    {
        _player = player;
        int ownerId = player.Piece.CurrentPlace.Owner.Id;
        SetPaymentUiText(ownerId,price);
        _paymentUi.SetActive(true);
    }
    public void HidePaymentMenu()
    {
        _paymentUi.SetActive(false);
    }

    void SetBuyPlaceUiText(float price)
    {
        _placePriceTxt.text = "Place Price: " + price.ToString();
    }
    void SetPaymentUiText(int OwnerId,float price)
    {
        _paymentTxt.text = "Debt: " + price.ToString();
        _paymentPlayerTxt.text = "Player " + OwnerId + " owns this place. You need to pay!";
    }
    void SetDiceUiPlayerTxt() 
    {
        string playerId = _dice.GetComponent<Player>().Id.ToString();
        _playerTurnTxt.text = "Player " + playerId + " turn";
    }

    public void BuyButton() // Will be called from button in UI
    {
        HideShopMenu();
        _player.Turn.PlaceChecker.ShopRules.BuyPlace();
    }
    public void NoBuyButton() // Will be called from button in UI
    {
        HideShopMenu();
        _player.Turn.PlaceChecker.ShopRules.FinishCheck();
    }

    public void PayButton() // Will be called from button in UI
    {
        HidePaymentMenu();
        _player.Turn.PlaceChecker.ShopRules.PayDebt();
    }

}
