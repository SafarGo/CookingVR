using UnityEngine;
using UnityEngine.UIElements;

public class VitezhkaController : MonoBehaviour
{
    [SerializeField] private float force;

    private void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (rb != null)
        {
            Vector3 direction = (transform.position - other.transform.position).normalized;
            rb.AddForce(direction * force);
        }
    }
}
