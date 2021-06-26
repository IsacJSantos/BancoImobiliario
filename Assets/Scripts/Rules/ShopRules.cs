using UnityEngine;
using System;
using UnityEngine.UI;

public class ShopRules : MonoBehaviour
{
    public event EventHandler IsFinish;

    UIController _uIController;
    PlayerRemove _playerRemove;
    UiMessenger _uiMessanger;

    private void Awake()
    {
        Events.OnShop += PlayerShopChoose;
        Events.OnInitShopRules += ShowShopMenu;
    }
    private void Start()
    {
        _uIController = GameObject.FindGameObjectWithTag("UiController").GetComponent<UIController>();
        _playerRemove = GameObject.FindGameObjectWithTag("Party").GetComponent<PlayerRemove>();
        _uiMessanger = GameObject.FindGameObjectWithTag("MessageController").GetComponent<UiMessenger>();
    }
    private void OnDestroy()
    {
        Events.OnShop -= PlayerShopChoose;
        Events.OnInitShopRules -= ShowShopMenu;
    }

    void ShowShopMenu(MenuShopType type, Player player)
    {
        switch (type)
        {
            case MenuShopType.Shop:
                ShopMenu(player);
                break;
            case MenuShopType.Payment:
                PaymentMenu(player);
                break;
            default:
                Debug.LogError("Menu type not found");
                break;
        }
    }

    void PlayerShopChoose(ShopType shopType, Player player) 
    {
        switch (shopType)
        {
            case ShopType.Buy:
                BuyPlace(player);
                break;
            case ShopType.NoBuy:
                FinishCheck();
                break;
            case ShopType.Payment:
                PayDebt(player);
                break;
            default:
                break;
        }
    }


    void PaymentMenu(Player player)
    {
        int price = (int)(player.piece.CurrentPlace.GetCost() / 2);
        _uIController.ShowPaymentMenu(player, price);
    }
    void ShopMenu(Player player)
    {
        float price = player.piece.CurrentPlace.GetCost();
        _uIController.ShowShopMenu(player, price);
    }

    public void FinishCheck()
    {
        Events.OnShopFinish?.Invoke();
    }

    public void BuyPlace(Player player)
    {
        if (CanBuy(player))
            Buy(player);
        else
            _uiMessanger.SendTxtUiMessage("This player can't pay!");

        FinishCheck();
    }
    public void PayDebt(Player player)
    {
        if (CanPayDebt(player))
            Pay(player);
        else
            RemovePlayer(player);

        FinishCheck();
    }

    void RemovePlayer(Player player)
    {
        if (_playerRemove)
            _playerRemove.RemovePlayerFromParty(player);

        _uiMessanger.SendTxtUiMessage("Player " + player.id + " lose!");
        FinishCheck();
    }
    bool CanPayDebt(Player player)
    {
        return (int)(player.piece.CurrentPlace.GetCost() / 2) <= player.GetPoints();
    }
    bool CanBuy(Player player)
    {
        return player.piece.CurrentPlace.GetCost() <= player.GetPoints();
    }

    void Pay(Player player)
    {
        Player placeOwner = player.piece.CurrentPlace.Owner;
        int debt = (int)(player.piece.CurrentPlace.GetCost() / 2);
        player.SetPoints(player.GetPoints() - debt);
        placeOwner.SetPoints(placeOwner.GetPoints() + debt);
    }
    void Buy(Player player)
    {
        Place place = player.piece.CurrentPlace;
        player.SetPoints(player.GetPoints() - place.GetCost());
        place.Owner = player;
        player.properties.Add(place);
    }
}
