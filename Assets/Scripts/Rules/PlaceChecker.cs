using UnityEngine;
using System;
using UnityEngine.UI;

public class PlaceChecker : MonoBehaviour
{
 
    public ShopRules ShopRules { get; set; }
    Player _player;

    private void Start()
    {
        ShopRules = GetComponent<ShopRules>();
        _player = GetComponent<Player>();

    }

    public void CheckPlace() // Will be called from TurnActions
    {
        CheckOwner();
    }

    public void ShopFinish() 
    {
        _player.Turn.CheckFinish();
    }
   
    void CheckOwner() 
    {
        if (!PlaceBuyable()) 
        {
            _player.Turn.CheckFinish();
            return;
        }
           

        if (HasOuwner())
        {
            if (IsThisPlayerOwner())
            {
                gameObject.SendMessage("CheckFinish");
            }
            else
            {
                ShopRules.PaymentMenu();
            }
        }
        else 
        {
            ShopRules.ShopMenu();
        }
    }

    bool PlaceBuyable() 
    {
        return _player.Piece.CurrentPlace.CanBePurchased;
    }
    bool IsThisPlayerOwner() 
    {
        return _player.Piece.CurrentPlace.Owner == _player;
    }
    bool HasOuwner()
    {
        return _player.Piece.CurrentPlace.Owner != null;
    }


}
