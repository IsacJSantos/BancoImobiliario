using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class PlayersConfigPanel : MonoBehaviour
{
    [SerializeField]
    List<PlayerPanel> pPanelList = new List<PlayerPanel>();

    [SerializeField] string playerPanelPath;
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
            pPanelList.Add(Instantiate(Resources.Load<GameObject>(playerPanelPath), contentParent, false).GetComponent<PlayerPanel>());
        }

    }

}
