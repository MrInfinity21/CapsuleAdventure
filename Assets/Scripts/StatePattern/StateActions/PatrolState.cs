using UnityEngine;

public class PatrolState : IState
{
    private StateManager _stateManager;

    public PatrolState(StateManager stateManager)
    {
        _stateManager = stateManager;
    }
    public void Enter()
    {
        Debug.Log("Entering Patrol State");
    }

    public void Exit()
    {
        Debug.Log("Exiting Patrol State");
    }

    public void Update()
    {

    }
    public void FixedUpdate()
    {
        if (_stateManager.PlayerChecker.IsPlayerInRange())
        {
            _stateManager.ChangeState(_stateManager.ChaseState);
        }
    }

 
}
