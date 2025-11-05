using UnityEngine;

public class ChaseState : IState
{
    private StateManager _stateManager;

    public ChaseState(StateManager stateManager)
    {
        _stateManager = stateManager;
    }
    public void Enter()
    {
        Debug.Log("Entering Chase State");
    }

    public void Exit()
    {
        Debug.Log("Exiting Chase State");
    }

    public void Update()
    {

    }
    public void FixedUpdate()
    {
        if (_stateManager.PlayerChecker.IsPlayerInRange())
        {
            _stateManager.CharacterMover.MoveTo(_stateManager.PlayerChecker.GetPlayerPosition());
        }
        else
        {
            _stateManager.ChangeState(_stateManager.PatrolState);
        }
    }

 

}
