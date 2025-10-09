using UnityEngine;

public class SpeakCommand : ICommand
{

    private string _message;

    public SpeakCommand(string message)
    {
        _message = message;
    }
    public void Execute()
    {
        Debug.Log(_message);
    }

    public bool IsComplete()
    {
        return true;
    }
    
}
