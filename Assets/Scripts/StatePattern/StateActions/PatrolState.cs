using UnityEngine;

public class PatrolState : IState
{
    private StateManager _stateManager;
    private Transform[] _patrolPoints;
    private int _currentPointIndex;
    private float _waitTimer;
    private float _waitDuration = 2f;

    public PatrolState(StateManager stateManager)
    {
        _stateManager = stateManager;
        _patrolPoints = _stateManager.PatrolPoints;
        _currentPointIndex = 0;
    }
    public void Enter()
    {
        Debug.Log("Entering Patrol State");
        MoveToNextPoint();
    }

    public void Exit()
    {
        Debug.Log("Exiting Patrol State");
    }

    public void Update()
    {
        if (_stateManager.PlayerChecker.IsPlayerInRange())
        {
            _stateManager.ChangeState(_stateManager.ChaseState);
            return;
        }

        if (_patrolPoints == null || _patrolPoints.Length == 0)
            return;

        var agent = _stateManager.CharacterMover.GetComponent<UnityEngine.AI.NavMeshAgent>();
        if(!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            _waitTimer += Time.deltaTime;

            if (_waitTimer >= _waitDuration)
            {
                MoveToNextPoint();
                _waitTimer = 0f;
            }
        }
    }
    public void FixedUpdate()
    {
        
    }

    private void MoveToNextPoint()
    {
        if(_patrolPoints == null || _patrolPoints.Length == 0)
            return;

        _stateManager.CharacterMover.MoveTo(_patrolPoints[_currentPointIndex].position);
        _currentPointIndex = (_currentPointIndex + 1 ) % _patrolPoints.Length;
    }

 
}
