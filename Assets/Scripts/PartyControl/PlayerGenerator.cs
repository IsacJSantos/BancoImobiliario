using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject[] _playerPrefabs;
    [SerializeField]
    GameObject _playerPrefab, _playerScoreInfoPrefab;
    [SerializeField]
    GameObject _parentPlayerScoreInfo;
    [SerializeField]
    Text _diceSortTxt;
    [SerializeField]
    float _playersInitialPoins;

    Party _party;
    Board _board;
    private void Start()
    {
        _party = GameObject.FindGameObjectWithTag("Party").GetComponent<Party>();
        _board = GameObject.FindGameObjectWithTag("Board").GetComponent<Board>();
    }
    public void Generate(int amount)
    {
        StartCoroutine(GeneratePlayersRoutine(amount));
    }

    IEnumerator GeneratePlayersRoutine(int amount)
    {
        Vector3 pos = _board.Places[0]._PieceFieldPos.position;
        for (int i = 0; i < amount; i++)
        {
            Player player = SortAPlayerModel(pos).GetComponent<Player>();
            player.Id = i + 1; // Set player id
            player.SetPlayerScoreInfo(GenerateScoreTextInfo(player.Id)); // Set a score info that will be show in ui
            player.SetPoints(_playersInitialPoins); // Set player points

            _party.Players.Add(player); // Put player in party players list
            yield return null;
        }
        _party.StartParty();

    }

    GameObject SortAPlayerModel(Vector3 pos) 
    {
        int x = Random.Range(0, _playerPrefabs.Length);
        GameObject randomPlayer = Instantiate(_playerPrefabs[x], pos, Quaternion.identity);
        return randomPlayer;
    }
    PlayerScoreInfoController GenerateScoreTextInfo(int playerId) 
    {
       PlayerScoreInfoController playerScore = Instantiate(_playerScoreInfoPrefab,
                                                            _parentPlayerScoreInfo.transform.position,
                                                            Quaternion.identity).GetComponent<PlayerScoreInfoController>();

        playerScore.transform.SetParent(_parentPlayerScoreInfo.transform);
        playerScore.SetScoreInfo(playerId);
        return playerScore;
    }
}
