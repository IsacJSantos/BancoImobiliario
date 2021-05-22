using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animation))]
public class Piece : MonoBehaviour, IPiece
{
    public Place CurrentPlace { get; private set; }
    public Animation Anim { get; private set; }

    [SerializeField] protected Board _board;
    [SerializeField] protected string idleAnimName;
    [SerializeField] protected string moveAnimName;
   
    protected private int _currentPlaceIndex;
    protected bool _isMoving;

    const string IDLE_NAME_ANIM = "Idle_Anim";
    const string MOVE_NAME_ANIM = "Move_Anim";
    private void Start()
    {
        Anim = GetComponent<Animation>();

        _board = GameObject.FindGameObjectWithTag("Board").GetComponent<Board>();

        if (_board)
            CurrentPlace = _board.Places[0];
        else       
            Debug.Log("No board were found");

        idleAnimName = string.IsNullOrEmpty(idleAnimName) ? IDLE_NAME_ANIM : idleAnimName;
        moveAnimName = string.IsNullOrEmpty(moveAnimName) ? MOVE_NAME_ANIM : moveAnimName;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Anim.Play(moveAnimName);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Anim.Play();
        }
    }

    public void PlayWalkAnim()
    {
        Anim.Play(moveAnimName);
    }

    public void PlayIdleAnim()
    {
        Anim.Play(idleAnimName);
    }

    public virtual void Move(int movements,int id)
    {
        if (!_isMoving)
        {
            _isMoving = true;
            StartCoroutine(MovimentRoutine(movements,id));
        }

    }
    protected virtual void Movement(Vector3 target)
    {
        Anim.Play(moveAnimName);
        transform.position = Vector3.MoveTowards(transform.position, target, 2.5f * Time.deltaTime);
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
   
}
