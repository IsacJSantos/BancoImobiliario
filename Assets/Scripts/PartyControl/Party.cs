using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Party : MonoBehaviour
{
    public bool PartyFinish;
    public List<Player> Players = new List<Player>();
    int index;

    private void Awake()
    {
        Events.OnFinishTurn += FinishTurn;
    }

    private void OnDestroy()
    {
        Events.OnFinishTurn -= FinishTurn;
    }

    public void StartParty()
    {
        NextTurn();
    }

    void FinishTurn()
    {
        if (Players.Count > 1)
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
        if (player != null)
            Events.OnInitTurn?.Invoke(player);

        index++;
    }
}
