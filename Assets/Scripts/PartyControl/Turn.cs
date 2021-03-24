using UnityEngine;
using System;

public class Turn : MonoBehaviour
{
    public event EventHandler IsFinish;

    [SerializeField]
    TurnActions _actions;
    public Player temp;

    private void Start()
    {
        _actions.IsFinish += _actions_IsFinish;
    }

    private void _actions_IsFinish(object sender, EventArgs e)
    {
        IsFinish?.Invoke(this, EventArgs.Empty);
    }

    public void InitTurn(/*Player player*/) 
    {
        _actions.InitActions(temp);
    }
}
