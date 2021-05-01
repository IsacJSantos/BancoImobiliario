using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    [SerializeField] string playerSkinPath;

    private void Start()
    {
        foreach (var item in Resources.Load<PLayerContainer>(playerSkinPath).players)
        {
            Debug.Log(item.GetComponent<Player>().playerName);
        }
    }
}
