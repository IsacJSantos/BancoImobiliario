using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Events : MonoBehaviour
{
    public static ListPlayerDataEvent OnSetPlayerDataList;


    public static SimpleEvent OnFinishTurn;
    public static PlayerEvent OnAddPlayerToList;

    public static IntEvent OnDiceFinish;
    public static SimpleEvent OnRollDice;

    public static PlayerEvent OnInitTurn;

    public static IntIntEvent OnPlayerMove;
    public static SimpleEvent OnPlayerFinishMove;

    public static PlayerEvent OnCheckPlace;
    public static SimpleEvent OnCheckPlaceFinish;


    public static SimpleEvent OnShopFinish;
    public static MenuShopTypePlayerEvent OnInitShopRules;
    public static ShopTypePlayerEvent OnShop;

    public static IntEvent OnGeneratePlayerPanel;


    public delegate void SimpleEvent();
    public delegate void IntEvent(int i);
    public delegate void IntIntEvent(int i1, int i2);
    public delegate void PlayerEvent(Player p);
    public delegate void ListPlayerDataEvent(List<PlayerData> players);
    public delegate void MenuShopTypePlayerEvent(MenuShopType mst, Player p);
    public delegate void ShopTypePlayerEvent(ShopType st, Player p);

}
