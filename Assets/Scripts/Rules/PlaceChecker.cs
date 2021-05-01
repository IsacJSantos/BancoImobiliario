using UnityEngine;
using System;
using UnityEngine.UI;

public class PlaceChecker : MonoBehaviour
{
 
    private void Awake()
    {
        Events.OnShopFinish += ShopFinish;
        Events.OnCheckPlace += CheckPlace;
    }

    private void OnDestroy()
    {
        Events.OnShopFinish -= ShopFinish;
        Events.OnCheckPlace -= CheckPlace;
    }

    public void CheckPlace(Player p) // Will be called from TurnActions
    {
        CheckOwner(p);
    }

    public void ShopFinish() 
    {
        Events.OnCheckPlaceFinish?.Invoke();
    }
   
    void CheckOwner(Player player) 
    {
        if (!PlaceBuyable(player)) 
        {
            Events.OnCheckPlaceFinish?.Invoke();
            return;
        }
           

        if (HasOuwner(player))
        {
            if (IsThisPlayerOwner(player))
            {
                Events.OnCheckPlaceFinish?.Invoke();
            }
            else
            {
                Events.OnInitShopRules?.Invoke(MenuShopType.Payment,player);
            }
        }
        else 
        {
            Events.OnInitShopRules?.Invoke(MenuShopType.Shop, player);
        }
    }

    bool PlaceBuyable(Player player) 
    {
        return player.Piece.CurrentPlace.CanBePurchased;
    }
    bool IsThisPlayerOwner(Player player) 
    {
        return player.Piece.CurrentPlace.Owner == player;
    }
    bool HasOuwner(Player player)
    {
        return player.Piece.CurrentPlace.Owner != null;
    }


}
public enum MenuShopType 
{
    Shop,
    Payment
}
