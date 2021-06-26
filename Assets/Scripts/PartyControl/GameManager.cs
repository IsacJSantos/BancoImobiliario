using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager _instance;
    public static GameManager Instance => _instance;

    bool _isStopping;

    public List<PlayerData> PlayersData = new List<PlayerData>();

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != null && _instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        Events.OnSetPlayerDataList += SetPlayersData;
    }
    private void Start()
    {
        SceneManager.LoadScene(1);
    }
    private void OnDestroy()
    {
        Events.OnSetPlayerDataList -= SetPlayersData;
    }
    public void SetPlayersData(List<PlayerData> _players) 
    {
        PlayersData.Clear();
        PlayersData = _players;
        SceneManager.LoadScene(2);
    }
    public void GameOver(Player player) 
    {
      
    }

    public void StopGameButton(List<Player> _players) 
    {
        if (!_isStopping)
            StartCoroutine(StopGameRoutine(_players));
    }
  
    IEnumerator StopGameRoutine(List<Player> _players) 
    {
        _isStopping = true;
        Player bestPlayer = _players.ElementAt(0);
        foreach (var player in _players)
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
