using UnityEngine;

public class SliderObject : MonoBehaviour
{
    [SerializeField] private float minz = -1f;
    [SerializeField] private float maxz = 1f;

    private void Update()
    {
        Vector3 pos = transform.position;
        pos.x = transform.position.x;
        pos.z = transform.position.y;
        pos.y = Mathf.Clamp(pos.z, minz, maxz); 
        transform.position = pos;
    }
}