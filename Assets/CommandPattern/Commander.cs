using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class Commander : MonoBehaviour
{

    [Header("Command References")]
    
    public GameObject buildingPrefab;
    
    public Transform[] _destination;

    public NavMeshAgent _agent;



    private ICommand _currentCommand; //The Current command being executed
    
    private Queue<ICommand> _commandQueue = new(); //Queue to hold commands

    void Start()
    {
        // populate the command queue

        _commandQueue.Enqueue(new MoveCommand(_agent, _destination[0].position));
        _commandQueue.Enqueue(new StayCommand(2));

        _commandQueue.Enqueue(new MoveCommand(_agent, _destination[1].position));
        _commandQueue.Enqueue(new StayCommand(2));
        
        _commandQueue.Enqueue(new BuildCommand(buildingPrefab, _destination[1].position));
        _commandQueue.Enqueue(new StayCommand(2));
        
        _commandQueue.Enqueue(new MoveCommand(_agent, _destination[2].position));
        _commandQueue.Enqueue(new StayCommand(2));
        
        _commandQueue.Enqueue(new SpeakCommand("Ok Boss"));
    }

    void Update()
    {
        // if there is no current command and there are commands in the queue
        if (_currentCommand == null && _commandQueue.Count > 0) 
        {
            _currentCommand = _commandQueue.Dequeue(); // Get the next  command from the queue
            _currentCommand.Execute(); // Execute the command
        }        

        // If there is a current command, check if it's complete
        if(_currentCommand !=null && _currentCommand.IsComplete())
        {
            _currentCommand = null; // Clear the current command
        }
    }
}
