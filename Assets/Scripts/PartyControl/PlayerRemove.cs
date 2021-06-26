using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRemove : MonoBehaviour
{
    Party _party;

    private void Start()
    {
        _party = GetComponent<Party>();
    }

    public void RemovePlayerFromParty(Player player)
    {
        _party.Players.Remove(player);
        StartCoroutine(RemovePropertiesRoutine(player));
    }

    IEnumerator RemovePropertiesRoutine(Player player) 
    {
        foreach (var place in player.properties)
        {
            place.Owner = null;
            yield return null;
        }
        Destroy(player.GetPlayerScoreInfo().gameObject);
        //Destroy(player.gameObject);
    }
}
