using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 50f;
    [SerializeField] private Vector3 _rotationAxis = new Vector3(0,1,0);
    void Update()
    {
        transform.Rotate(_rotationAxis * _rotationSpeed * Time.deltaTime);
    }
}
