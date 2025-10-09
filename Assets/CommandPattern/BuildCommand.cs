using UnityEngine;

public class BuildCommand : ICommand
{
    private GameObject _buildingPrefabs;

    private Vector3 _postion;

    public BuildCommand(GameObject buildingPrefab, Vector3 position)
    {
        _buildingPrefabs = buildingPrefab;
        _postion = position;

    }

    public void Execute()
    {
        Debug.Log("Gonna build something over here!");
        GameObject.Instantiate(_buildingPrefabs, _postion, Quaternion.identity);
    }

    public bool IsComplete()
    {
        return true;
    }
}
