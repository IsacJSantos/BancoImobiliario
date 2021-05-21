using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Piece : MonoBehaviour
{

    public Place CurrentPlace { get; private set; }

    [SerializeField]
    Board _board;

    private int _currentPlaceIndex;
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

    public void Move(int movements,int id)
    {
        if (!_isMoving)
        {
            _isMoving = true;
            StartCoroutine(MovimentRoutine(movements,id));
        }

    }

    IEnumerator MovimentRoutine(int movements,int id)
    {
        int _movementsAmount = movements;
        while (_movementsAmount > 0)
        {
            _movementsAmount--;
            Vector3 target = SetTarget(id);
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

    Vector3 SetTarget(int playerId)
    {
        Vector3 newPos;
        if (_currentPlaceIndex >= _board.Places.Length - 1)// If this piece is on final place
        {
            _currentPlaceIndex = 0;
            newPos = new Vector3(_board.Places[0].PiecePositions[playerId].position.x
                                        , transform.position.y
                                        , _board.Places[0].PiecePositions[playerId].position.z
                                        );

            CurrentPlace = _board.Places[0];
            return newPos;
        }

        _currentPlaceIndex++;
        newPos = new Vector3(_board.Places[_currentPlaceIndex].PiecePositions[playerId].position.x
                                        , transform.position.y
                                        , _board.Places[_currentPlaceIndex].PiecePositions[playerId].position.z
                                        );

        CurrentPlace = _board.Places[_currentPlaceIndex];
        return newPos;
    }
    void Movement(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, 2.5f * Time.deltaTime);
    }
}
