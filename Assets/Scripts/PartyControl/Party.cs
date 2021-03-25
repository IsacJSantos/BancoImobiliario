using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Party : MonoBehaviour
{
    public bool PartyFinish;
    public List<Player> Players = new List<Player>();
    [SerializeField]
    int index;
   
    public void StartParty() 
    {
        NextTurn();
    }
    public void FinishTurn() 
    {
        if(Players.Count > 1) 
        {
            NextTurn();
        }
        else
        {
            PartyFinish = true;
        }
    }

    void NextTurn()
    {
        if (index > Players.Count - 1)
            index = 0;

        Player player = Players.ElementAt(index);
        if (player)
            player.Turn.InitTurn();

        index++;
    }
}
