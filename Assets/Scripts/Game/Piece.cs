using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public bool isFinish { get; private set; }
    [SerializeField]
    Board _board;

    int _movimentsAmount; // total of moviments
    public void Move(int moviments)
    {
        _movimentsAmount = moviments;
        StartCoroutine(MovimentRoutine());
    }
    IEnumerator MovimentRoutine() 
    {
        return null;
    }
}
