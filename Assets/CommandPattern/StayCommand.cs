using UnityEngine;
using UnityEngine.Rendering;

public class StayCommand : ICommand
{

    private float _duration;

    private float _currentTime;


    public StayCommand(float duration)
    {
        _duration = duration;
    }
    public void Execute()
    {
        _currentTime = 0;
        Debug.Log($"Lemme wait for {_duration} seconds");
        
    }

    public bool IsComplete()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime >= _duration) 
        {
            Debug.Log("I'm done waiting!");
            return true;
        }

        return false;
    }

}
