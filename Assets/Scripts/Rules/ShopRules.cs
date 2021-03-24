using UnityEngine;
using System;
using UnityEngine.UI;

public class ShopRules : MonoBehaviour
{
    public event EventHandler IsFinish;
   
    UIController _uIController;
    Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
        _uIController = GameObject.FindGameObjectWithTag("UiController").GetComponent<UIController>();
    }
    public void PaymentMenu()
    {
        int price = (int)(_player.Piece.CurrentPlace.GetCost() / 2);
        _uIController.ShowPaymentMenu(_player,price);
        print("Paymentmenu");
    }
    public void ShopMenu()
    {
        float price = _player.Piece.CurrentPlace.GetCost();
        _uIController.ShowShopMenu(_player,price);
        print("ShopMenu");
    }

    public void FinishCheck() 
    {
        _player.Turn.PlaceChecker.ShopFinish();
    }

   /* public void BuyButton() // Will be called from button in UI
    {
        BuyPlace();
        _uIController.HideShopMenu();
        IsFinish?.Invoke(this, EventArgs.Empty);
    }
    public void NoBuyButton() // Will be called from button in UI
    {
        _uIController.HideShopMenu();
        IsFinish?.Invoke(this, EventArgs.Empty);
    }

    public void PayButton() // Will be called from button in UI
    {
        PayDebt();
        _uIController.HidePaymentMenu();
        IsFinish?.Invoke(this, EventArgs.Empty);
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
    }*/
}
