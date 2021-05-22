using System.Collections.Generic;
using UnityEngine;


public class PlayersConfigPanel : MonoBehaviour
{ 
    [SerializeField] Board board;
    [SerializeField] string playerPanelPath;
    [SerializeField] string playerSkinPath;
    [SerializeField] Transform contentParent;

    List<PlayerPanel> pPanelList = new List<PlayerPanel>();

    private void Awake()
    {
        Events.OnGeneratePlayerPanel += GeneratePanel;
    }

    private void OnDestroy()
    {
        Events.OnGeneratePlayerPanel -= GeneratePanel;
    }

    public void GeneratePanel(int amount)
    {
        Debug.Log($"Generating {amount} players...");
        for (int i = 0; i < amount; i++)
        {
            pPanelList.Add(Instantiate(Resources.Load<GameObject>(playerPanelPath), contentParent, false).GetComponent<PlayerPanel>());
        }

    }

    public void ButtonPlay() 
    {
        int playerId = 0;

        foreach (var item in pPanelList)
        {
            Debug.LogWarning($"Player name is {item.Name}. Skin index is {item.Skin}");
            Vector3 pos = board.Places[0].PiecePositions[playerId].position;
            Player player = Instantiate(Resources.Load<PLayerContainer>(playerSkinPath).playerData[item.Skin].playerPrefab, pos, Quaternion.identity).GetComponent<Player>();
            player.playerName = string.IsNullOrEmpty(item.Name)? $"Player{playerId}": item.Name;
            player.Id = playerId;
            Events.OnAddPlayerToList?.Invoke(player);

            playerId++;
        }
    }
}
