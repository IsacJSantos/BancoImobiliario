using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place : MonoBehaviour
{
    public float Cost{ get; private set; }

    [SerializeField]
    public Transform _PieceFieldPos { get; private set; } // Position what pieces will move to

    [SerializeField]
    Player _owner;

    private void Start()
    {
        _PieceFieldPos = GetComponentInChildren<Transform>();
    }

}
