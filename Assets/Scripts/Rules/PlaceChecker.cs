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
        if (HasOuwner())
        {
            if (IsThisPlayerOwner())
            {
                print("Is this " + _player.name + " owner");
                gameObject.SendMessage("CheckFinish");
            }
            else
            {
                print(_player.name + " is not owner");
                ShopRules.PaymentMenu();
            }
        }
        else 
        {
            ShopRules.ShopMenu();
        }
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
