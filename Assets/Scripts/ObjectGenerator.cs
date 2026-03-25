using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject objectToGenerate;
    public float generationInterval = 2f;

    private void Start()
    {
        if (objectToGenerate == null)
        {
            Debug.LogError("Object to generate is not assigned.");
        }
    }

    private void Update()
    {
        if (objectToGenerate != null)
        {
            generationInterval -= Time.deltaTime;
            if (generationInterval <= 0f)
            {
                Instantiate(objectToGenerate, transform.position, Quaternion.identity);
                generationInterval = 2f; // Reset the interval
            }
        }
    }
}
