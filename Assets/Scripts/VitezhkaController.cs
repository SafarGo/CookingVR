using UnityEngine;
using UnityEngine.UIElements;

public class VitezhkaController : MonoBehaviour
{
    [SerializeField] protected float force;

    protected virtual void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (rb != null && !GameManager.instance.isDebaf)
        {
            Vector3 direction = (transform.position - other.transform.position).normalized;
            rb.AddForce(direction * force);
        }
    }
}
