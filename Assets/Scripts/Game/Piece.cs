using System.Collections;
using UnityEngine;

public class Piece : MonoBehaviour
{

    public Place CurrentPlace { get; private set; }

    [SerializeField]
    Board _board;

    private int _currentPlaceIndex;
    int _movementsAmount; // Total of movements that Piece will do
    bool _isMoving;

    private void Start()
    {
        _board = GameObject.FindGameObjectWithTag("Board").GetComponent<Board>();
        if (_board)
            CurrentPlace = _board.Places[0];
        else
        {
            Debug.Log("None board");
        }
    }

    public void Move(int movements)
    {
        if (!_isMoving)
        {
            _isMoving = true;
            _movementsAmount = movements;
            StartCoroutine(MovimentRoutine());
        }

    }

    IEnumerator MovimentRoutine()
    {
        while (_movementsAmount > 0)
        {
            _movementsAmount--;
            Vector3 target = SetTarget();
            while (Vector3.Distance(transform.position, target) > 0.01f)
            {
                Movement(target);
                yield return null;
            }

            yield return new WaitForSeconds(0.2f);
        }
        _isMoving = false;
        Events.OnPlayerFinishMove?.Invoke();
    }

    Vector3 SetTarget()
    {
        Vector3 newPos;
        if (_currentPlaceIndex >= _board.Places.Length - 1)// If this piece is on final place
        {
            _currentPlaceIndex = 0;
            newPos = new Vector3(_board.Places[0]._PieceFieldPos.position.x
                                        , transform.position.y
                                        , _board.Places[0]._PieceFieldPos.position.z
                                        );

            CurrentPlace = _board.Places[0];
            return newPos;
        }

        _currentPlaceIndex++;
        newPos = new Vector3(_board.Places[_currentPlaceIndex]._PieceFieldPos.position.x
                                        , transform.position.y
                                        , _board.Places[_currentPlaceIndex]._PieceFieldPos.position.z
                                        );

        CurrentPlace = _board.Places[_currentPlaceIndex];
        return newPos;
    }
    void Movement(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, 2.5f * Time.deltaTime);
    }
}
