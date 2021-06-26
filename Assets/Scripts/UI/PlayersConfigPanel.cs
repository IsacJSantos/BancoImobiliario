using System.Collections.Generic;
using UnityEngine;


public class PlayersConfigPanel : MonoBehaviour
{
    [SerializeField] Board board;
    [SerializeField] Canvas canvas;
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
        canvas.enabled = true;
        for (int i = 0; i < amount; i++)
        {
            pPanelList.Add(Instantiate(Resources.Load<GameObject>(playerPanelPath), contentParent, false).GetComponent<PlayerPanel>());
        }

    }

    public void ButtonPlay()
    {
        int _playerId = 0;
        canvas.enabled = false;
        List<PlayerData> _players = new List<PlayerData>();
        foreach (var item in pPanelList)
        {
            PlayerData player = new PlayerData()
            {
                playerName = string.IsNullOrEmpty(item.Name) ? "Player " + _playerId : item.Name,
                id = _playerId,
                skinId = item.Skin
            };
            _players.Add(player);
            _playerId++;
        }
        Events.OnSetPlayerDataList?.Invoke(_players);
    }
}


