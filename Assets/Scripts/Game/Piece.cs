using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public bool IsFinish { get; private set; }
    public int PlaceIndex { get; private set; }
    [SerializeField]
    Board _board;

    int _movementsAmount; // Total of movements that Piece will do

    public void MoveRequest(int movements)
    {
        IsFinish = false;
        _movementsAmount = movements;
        StartCoroutine(MovimentRoutine());
    }

    IEnumerator MovimentRoutine()
    {
        while (_movementsAmount > 0)
        {
            _movementsAmount--;
            Vector3 target = setTarget();
            while (Vector3.Distance(transform.position,target) > 0.01f)
            {
                Movement(target);
                yield return null;
            }

            yield return new WaitForSeconds(0.3f);
        }
        IsFinish = true;
    }

    Vector3 setTarget() 
    {
        Vector3 newPos;
        if (PlaceIndex >= _board.Places.Length - 1)
        {
            PlaceIndex = 0;
            newPos = new Vector3(_board.Places[0]._PieceFieldPos.position.x
                                        , transform.position.y
                                        , _board.Places[0]._PieceFieldPos.position.z);
            return newPos;
        }
        PlaceIndex++;
        newPos = new Vector3(_board.Places[PlaceIndex]._PieceFieldPos.position.x
                                        , transform.position.y
                                        , _board.Places[PlaceIndex]._PieceFieldPos.position.z);
        return newPos;
    }
    void Movement(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, 1.6f * Time.deltaTime);
    }
}
