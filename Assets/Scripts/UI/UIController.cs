using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    GameObject _buyPlaceUi, _paymentUi, _diceUI;
    [SerializeField]
    Text _placePriceTxt, _paymentTxt;

    Player _player;
    Dice _dice;
    private void Start()
    {
        _diceUI.SetActive(true);
        _buyPlaceUi.SetActive(false);
        _paymentUi.SetActive(false);    
    }

    public void ShowDiceRoller(Dice dice) 
    {
        _dice = dice;
        _diceUI.SetActive(true);
    }
    public void HideDiceRoller() 
    {
        _dice = null;
        _diceUI.SetActive(false);
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
        SetPaymentUiText(price);
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
    void SetPaymentUiText(float price)
    {
        _paymentTxt.text = "Debt: " + price.ToString();
    }

    public void BuyButton() // Will be called from button in UI
    {
        BuyPlace();
        HideShopMenu();
        _player.Turn.PlaceChecker.ShopRules.FinishCheck();
    }
    public void NoBuyButton() // Will be called from button in UI
    {
        HideShopMenu();
        _player.Turn.PlaceChecker.ShopRules.FinishCheck();
    }

    public void PayButton() // Will be called from button in UI
    {
        PayDebt();
        HidePaymentMenu();
        _player.Turn.PlaceChecker.ShopRules.FinishCheck();
    }

    void BuyPlace()
    {
        if (CanBuy())
            Buy();
        else
            Debug.Log("Player can not buy this place");

    }
    void PayDebt()
    {
        if (CanPayDebt())
            Pay();
        else
            Debug.Log("Player must be removed");
    }

    bool CanPayDebt()
    {
        return (int)(_player.Piece.CurrentPlace.GetCost() / 2) <= _player.Points;
    }
    bool CanBuy()
    {
        return _player.Piece.CurrentPlace.GetCost() <= _player.Points;
    }

    void Pay()
    {
        Player placeOwner = _player.Piece.CurrentPlace.Owner;
        int debt = (int)(_player.Piece.CurrentPlace.GetCost() / 2);
        _player.Points -= debt;
        placeOwner.Points += debt;
    }
    void Buy()
    {
        Place place = _player.Piece.CurrentPlace;
        _player.Points -= place.GetCost();
        place.Owner = _player;
        _player.Properties.Add(place);
    }
}
