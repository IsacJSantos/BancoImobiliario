using UnityEngine;
using System;
using UnityEngine.UI;

public class ShopRules : MonoBehaviour
{
    public event EventHandler IsFinish;
   
    UIController _uIController;
    Player _player;
    PlayerRemove _playerRemove;
    UiMessenger _uiMessanger;
    private void Start()
    {
        _player = GetComponent<Player>();
        _uIController = GameObject.FindGameObjectWithTag("UiController").GetComponent<UIController>();
        _playerRemove = GameObject.FindGameObjectWithTag("Party").GetComponent<PlayerRemove>();
        _uiMessanger = GameObject.FindGameObjectWithTag("MessageController").GetComponent<UiMessenger>();
    }
    public void PaymentMenu()
    {
        int price = (int)(_player.Piece.CurrentPlace.GetCost() / 2);
        _uIController.ShowPaymentMenu(_player,price);
    }
    public void ShopMenu()
    {
        float price = _player.Piece.CurrentPlace.GetCost();
        _uIController.ShowShopMenu(_player,price);
    }

    public void FinishCheck() 
    {
        _player.Turn.PlaceChecker.ShopFinish();
    }

    public void BuyPlace()
    {
        if (CanBuy())
            Buy();
        else
            _uiMessanger.SendTxtUiMessage("This player can't pay!");

        FinishCheck();
    }
    public void PayDebt()
    {
        if (CanPayDebt())
            Pay();
        else
            RemovePlayer();

        FinishCheck();
    }

    void RemovePlayer() 
    {
        if(_playerRemove)
        _playerRemove.RemovePlayerFromParty(_player);

        _uiMessanger.SendTxtUiMessage("Player " + _player.Id + " lose!");
        FinishCheck();
    }
    bool CanPayDebt()
    {
        return (int)(_player.Piece.CurrentPlace.GetCost() / 2) <= _player.GetPoints();
    }
    bool CanBuy()
    {
        return _player.Piece.CurrentPlace.GetCost() <= _player.GetPoints();
    }

    void Pay()
    {
        Player placeOwner = _player.Piece.CurrentPlace.Owner;
        int debt = (int)(_player.Piece.CurrentPlace.GetCost() / 2);
        _player.SetPoints(_player.GetPoints() - debt);
        placeOwner.SetPoints(placeOwner.GetPoints() + debt);
    }
    void Buy()
    {
        Place place = _player.Piece.CurrentPlace;
        _player.SetPoints(_player.GetPoints() - place.GetCost());
        place.Owner = _player;
        _player.Properties.Add(place);
    }
}
