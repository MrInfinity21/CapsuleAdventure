using UnityEngine;
using UnityEngine.AI;

public class CharacterMover : MonoBehaviour
{

    [SerializeField] private NavMeshAgent agent;

    private Vector3 _targetPosition;

    private void Start()
    {
        agent.stoppingDistance = 1f;
    }

    public void MoveTo(Transform targetTransform)
    {
        _targetPosition = targetTransform.position;
        agent.SetDestination(_targetPosition);
    }

    public void MoveTo(Vector3 targetPosition)
    {
        _targetPosition = targetPosition;
        agent.SetDestination(_targetPosition);
    }

}
