using UnityEngine;
using System;
using UnityEngine.UI;

public class PlaceChecker : MonoBehaviour
{
 
    public ShopRules ShopRules { get; set; }
    Player _player;

    private void Awake()
    {
        Events.OnCheckPlace += CheckPlace;
    }
    private void Start()
    {
        ShopRules = GetComponent<ShopRules>();
        _player = GetComponent<Player>();

    }

    private void OnDestroy()
    {
        Events.OnCheckPlace -= CheckPlace;
    }

    public void CheckPlace(Player p) // Will be called from TurnActions
    {
        _player = p;
        CheckOwner();
    }

    public void ShopFinish() 
    {
        Events.OnCheckPlaceFinish?.Invoke();
    }
   
    void CheckOwner() 
    {
        if (!PlaceBuyable()) 
        {
            Events.OnCheckPlaceFinish?.Invoke();
            return;
        }
           

        if (HasOuwner())
        {
            if (IsThisPlayerOwner())
            {
                Events.OnCheckPlaceFinish?.Invoke();
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
