using UnityEngine;

public class StateManager : MonoBehaviour
{

    //Various States

    private PatrolState _patrolState;

    private AlertState _alertState;
    
    private ChaseState _chaseState;
    
    private AttackState _attackState;

    //State Properties
    public PatrolState PatrolState => _patrolState;
    public AlertState AlertState => _alertState;
    public ChaseState ChaseState => _chaseState;
    public AttackState AttackState => _attackState;

    //References to components

    [SerializeField] private PlayerChecker playerChecker;
    public PlayerChecker PlayerChecker => playerChecker;

    [SerializeField] private CharacterMover characterMover;
    public CharacterMover CharacterMover => characterMover;

    //Keep track of the current state

    private IState _currentState;

    private void Awake()
    {
        _patrolState = new PatrolState(this);
        _alertState = new AlertState(this);
        _chaseState = new ChaseState(this);
        _attackState = new AttackState(this);



    }

    //Change the state
    public void ChangeState(IState newState)
    {
        //if there is an existing state, exit it
        _currentState?.Exit(); //? is null conditional operator

        //set the new state
        _currentState = newState;

        //enter the new state
        _currentState.Enter();
    }
    void Start()
    {
        ChangeState(_patrolState);
    }

    void Update()
    {
        // if there is a current state, update it
        _currentState?.Update();
    }
    private void FixedUpdate()
    {
        // if there is a current state, fixed update it 
        _currentState?.FixedUpdate();
    }
}
