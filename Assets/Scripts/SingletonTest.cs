using UnityEngine;

public class SingletonTest : MonoBehaviour
{
    public static SingletonTest Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }

        Destroy(gameObject);
    }

}
