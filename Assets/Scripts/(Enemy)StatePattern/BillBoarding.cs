using UnityEngine;

public class BillBoarding : MonoBehaviour
{
    [SerializeField] private Camera maincamera;

    private void Update()
    {
        Camera cam = Camera.main;
        if(cam != null)
        {
            transform.LookAt(cam.transform);
            transform.Rotate(0, 180, 0);
        }

    }
}
