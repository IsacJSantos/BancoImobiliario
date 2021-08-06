using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerAmount : MonoBehaviour
{
    [SerializeField] int maxPlayer;
    [SerializeField] int playerAmount;
    [SerializeField] TextMeshProUGUI amountTxt;
    [SerializeField] Canvas canvas;
    private void Awake()
    {
        playerAmount = 2;
    }
    public void ButtonSelect() 
    {    
        Events.OnGeneratePlayerPanel?.Invoke(playerAmount);
        canvas.enabled = false;

    }

    public void SelectPlayerAmount(int dir) // -1 to decrease and 1 to increase
    {
        if (dir != -1 && dir != 1) return;

        playerAmount += dir;

        if (playerAmount < 2)
            playerAmount = 2;
        else if (playerAmount > maxPlayer)
            playerAmount = maxPlayer;

        amountTxt.text = playerAmount.ToString();
    }
}
