using System.Collections.Generic;
using UnityEngine;

public class PlayerGenerator : MonoBehaviour
{
    [SerializeField] Board board;
    [SerializeField] string SkinContainerPath;
    [SerializeField] string PlayerPath;
    // Start is called before the first frame update
    void Start()
    {
        board = GameObject.FindGameObjectWithTag("Board").GetComponent<Board>();

        if (GameManager.Instance.PlayersData != null && GameManager.Instance.PlayersData.Count > 0)
            Generator(GameManager.Instance.PlayersData);
    }
   
    void Generator(List<PlayerData> _playersData)
    {
        if (!board) return;
        foreach (var item in _playersData)
        {
            Vector3 _pos = board.Places[0].PiecePositions[item.id].position;
            Piece _piece = Instantiate(Resources.Load<SkinContainer>(SkinContainerPath).playerData[item.skinId].playerPrefab,_pos,Quaternion.identity,transform).GetComponent<Piece>();
            Player _player = Instantiate(Resources.Load<GameObject>(PlayerPath)).GetComponent<Player>();
            _player.SetView(item,_piece);
            Events.OnAddPlayerToList(_player);
        }
    }
}
