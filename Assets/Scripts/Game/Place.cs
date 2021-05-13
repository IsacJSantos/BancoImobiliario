using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place : MonoBehaviour
{
  
    public bool CanBePurchased;
    public Player Owner;
    public Transform[] PiecePositions;

    [SerializeField]
    float _cost;

    public float GetCost() 
    {
        return _cost;
    }

}
