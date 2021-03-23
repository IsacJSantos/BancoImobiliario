using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    public bool isFinish { get; private set; }
    [SerializeField]
    TurnActions _actions;
    
}
