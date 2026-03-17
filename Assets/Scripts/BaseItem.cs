using UnityEngine;

public class BaseItem : MonoBehaviour
{
    [Header("Настройки Grabbable предметов")]
    [SerializeField] private float startImpulse;
    [SerializeField] private string itemName;
    [SerializeField] private bool isReady;
    [SerializeField] private bool isOnConveyor;

    [SerializeField] private Rigidbody rb;

    private void Update()
    {
        if(isOnConveyor)
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX;
            rb.linearVelocity = new Vector3(0, 0, 2);
        }
        else
        {
            rb.constraints = RigidbodyConstraints.None;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ConveyorLine"))
        {
            isOnConveyor = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ConveyorLine"))
        {
            isOnConveyor = false;
        }
    }
}