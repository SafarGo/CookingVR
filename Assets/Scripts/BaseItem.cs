using UnityEngine;

public class BaseItem : MonoBehaviour
{
    [Header("Настройки Grabbable предметов")]
    [SerializeField] private bool isMagnitizm;
    [SerializeField] private float startImpulse;
    [SerializeField] private string itemName;
    public bool isReady;
    [SerializeField] private bool isOnConveyor;
    [SerializeField] private bool isOnMagnit;
    [SerializeField] private float conveyorSpeed;

    [SerializeField] private Rigidbody rb;

    private void Start()
    {
        Vector3 randomDirection = Random.insideUnitSphere.normalized;
        rb.AddForce(randomDirection * startImpulse, ForceMode.Impulse);
    }
    private void Update()
    {
        OnMagnit();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (isMagnitizm)
        {
            if (other.CompareTag("ConveyorLine"))
            {
                isOnConveyor = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ConveyorLine"))
        {
            isOnConveyor = false;
        }
    }

    public void OnMagnit()
    {
        if (isOnConveyor && !GameManager.instance.isDebaf)
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX;
            rb.linearVelocity = new Vector3(0, 0, conveyorSpeed);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            rb.isKinematic = false;
            isOnMagnit = false;
            rb.constraints = RigidbodyConstraints.None;
        }
    }
}