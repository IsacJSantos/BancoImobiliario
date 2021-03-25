using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place : MonoBehaviour
{
    public Transform _PieceFieldPos { get; private set; } // Position what pieces will move to
    public bool CanBePurchased;
    public Player Owner;

    [SerializeField]
    float _cost;

    public float GetCost() 
    {
        return _cost;
    }
    private void Start()
    {
        _PieceFieldPos = GetComponentInChildren<Transform>();
    }

}
