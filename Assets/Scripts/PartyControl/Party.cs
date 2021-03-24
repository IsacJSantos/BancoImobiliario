using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Party : MonoBehaviour
{
    [SerializeField]
    List<Player> _players = new List<Player>();
    [SerializeField]
    int index;
    private void Start()
    {
        NextTurn();
    }

    public void FinishTurn() 
    {
        NextTurn();
    }

    void NextTurn()
    {
        Player player = _players.ElementAt(index);
        index++;
        if (player)
            player.Turn.InitTurn();

        if (index > _players.Count - 1)
            index = 0;
    }
}
