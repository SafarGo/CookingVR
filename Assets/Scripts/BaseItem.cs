using UnityEngine;

public class BaseItem : MonoBehaviour
{
    [Header("Настройки Grabbable предметов")]
    [SerializeField] private float startImpulse;
    [SerializeField] private string itemName;
    [SerializeField] private bool isReady;
    [SerializeField] private bool isOnConveyor;
    [SerializeField] private float conveyorSpeed;

    [SerializeField] private Rigidbody rb;

    private void Start()
    {
        Vector3 randomDirection = Random.insideUnitSphere.normalized;
        rb.AddForce(randomDirection * startImpulse, ForceMode.Impulse);
    }
    private void Update()
    {
        if(isOnConveyor)
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX;
            rb.linearVelocity = new Vector3(0, 0, conveyorSpeed);
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