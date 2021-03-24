using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Turn Turn;
    public Piece Piece;
    public float Points;
    public List<Place> Properties = new List<Place>();

    private void Start()
    {
        Turn = GetComponent<Turn>();
    }
}
