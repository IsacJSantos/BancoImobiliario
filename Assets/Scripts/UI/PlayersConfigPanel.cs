using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersConfigPanel : MonoBehaviour
{
    [SerializeField]
    List<PlayerPanel> pPanelList = new List<PlayerPanel>();

    [SerializeField] GameObject playerPanelPrefab;
    [SerializeField] Transform contentParent;

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
            pPanelList.Add(Instantiate(playerPanelPrefab, contentParent, false).GetComponent<PlayerPanel>());
        }

    }

}
