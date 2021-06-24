using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager _instance;
    public static GameManager Instance;

    bool _isStopping;

    public List<PlayerPanel> PlayerPanels = new List<PlayerPanel>();
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != null && _instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        SceneManager.LoadScene(1);
    }
    public void SetPlayers(List<PlayerPanel> _players) 
    {
        PlayerPanels.Clear();
        PlayerPanels = _players;
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
