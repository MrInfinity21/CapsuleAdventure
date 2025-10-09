using UnityEngine;

public class SampleService : MonoBehaviour
{
    void Awake()
    {
        ServiceLocator.Instance.Register<SampleService>(this);
    }
    public void Hey()
    {
        Debug.Log("Hey!!!");
    }
}
