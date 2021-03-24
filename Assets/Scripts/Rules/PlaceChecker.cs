using UnityEngine;
using System;
using UnityEngine.UI;

public class PlaceChecker : MonoBehaviour
{
    public event EventHandler IsFinish;
    [SerializeField]
    UIController uIController;

    Player _player;

    public void CheckPlace(Player player)
    {
        print(1);
        _player = player;
        StartCheck();
    }

    public void BuyButton() // Will be call from button in UI
    {
        uIController.HideShopMenu();
        IsFinish?.Invoke(this, EventArgs.Empty);
    }
    public void NoBuyButton() // Will be call from button in UI
    {
        uIController.HideShopMenu();
        IsFinish?.Invoke(this, EventArgs.Empty);
    }

    void StartCheck()
    {

        if (HasOuwner())
        {
            //
        }
        else
        {
            uIController.ShowShopMenu();
        }
    }

    bool HasOuwner()
    {
        return _player.Piece.CurrentPlace == null;
    }


}
