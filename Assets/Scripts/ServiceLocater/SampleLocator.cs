using UnityEngine;

public class SampleLocator : MonoBehaviour
{
    
    void Start()
    {
        ServiceLocator.Instance.GetService<SampleService>().Hey();
    }

    
    
}
