using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;

public class GameController : MonoBehaviour
{
    [SerializeField]
    GameObject _partyInitUi, _gameOverUi;
    [SerializeField]
    Text _playerWinTxt, _playerPointsTxt;
    [SerializeField]
    InputField _input;

    bool _isStopping;
    Party _party;
    PlayerGenerator _playerGenerator;

    private void Update()
    {
        if (_party.PartyFinish)
        {
            _party.PartyFinish = false;
            GameOver(_party.Players.ElementAt(0));
        }
    }
    private void Start()
    {
        _partyInitUi.SetActive(true);
        _gameOverUi.SetActive(false);
        _party = GameObject.FindGameObjectWithTag("Party").GetComponent<Party>();
        _playerGenerator = GetComponent<PlayerGenerator>();
    }

    public void GameOver(Player player) 
    {
        SetWinnerInfosUi(player.Id, player.GetPoints());
        _gameOverUi.SetActive(true);
    }
    public void PlayButton() 
    {
        int playersAmount = int.Parse(_input.text);
        if (playersAmount > 1)
        {
            _playerGenerator.Generate(playersAmount);
            _partyInitUi.SetActive(false);
        }
    }

    public void StopGameButton() 
    {
        if (!_isStopping)
            StartCoroutine(StopGameRoutine());
    }
    void SetWinnerInfosUi(int playerId, float playerPoints) 
    {
        _playerWinTxt.text = "Player " + playerId.ToString() + " win!";
        _playerPointsTxt.text = "With " + playerPoints.ToString() + " points!";
    }

    IEnumerator StopGameRoutine() 
    {
        _isStopping = true;
        Player bestPlayer = _party.Players.ElementAt(0);
        foreach (var player in _party.Players)
        {
            if (bestPlayer.GetPoints() < player.GetPoints())
            {
                bestPlayer = player;
            }
            
            yield return null;
        }
        GameOver(bestPlayer);
    }
}
