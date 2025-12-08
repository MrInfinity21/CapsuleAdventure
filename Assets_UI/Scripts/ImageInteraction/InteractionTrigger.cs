using UnityEngine;

public class InteractionTrigger : MonoBehaviour
{
    public GameObject _Canvas;
    public Color gizmoColor = Color.yellow;

 

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && _Canvas != null)
        {
            _Canvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && _Canvas != null)
        {
            _Canvas.SetActive(false);
        }
    }


    private void OnDrawGizmos()
    {
        SphereCollider sphere = GetComponent<SphereCollider>();
        if(sphere == null) return;

        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position + sphere.center, sphere.radius);
    }
}
