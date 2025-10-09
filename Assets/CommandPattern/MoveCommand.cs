using UnityEngine;
using UnityEngine.AI;
public class MoveCommand : ICommand
{
    private NavMeshAgent _agent;

    private Vector3 _destination;
    
    public MoveCommand(NavMeshAgent agent, Vector3 destination)
    {
        _agent = agent;
        _destination = destination;
    }
    public void Execute()
    {
        _agent.SetDestination(_destination);
        Debug.Log("Moving to " +  _destination);
    }

    public bool IsComplete()
    {
        if(_agent.remainingDistance <= 0.1f)
        {
            Debug.Log("Arrived at " + _destination);
            return true;
        }

        return false;
    }
}
