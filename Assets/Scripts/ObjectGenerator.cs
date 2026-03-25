using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    [System.Serializable]
    public struct ProductEntry
    {
        public string tag;
        public GameObject prefab;
    }

    public List<ProductEntry> productList = new List<ProductEntry>();

    private Dictionary<string, GameObject> products = new Dictionary<string, GameObject>();

    private void Awake()
    {
        foreach (var entry in productList)
            products[entry.tag] = entry.prefab;
    }

    private void OnTriggerExit(Collider other)
    {
        if (products.TryGetValue(other.tag, out GameObject prefab))
            Instantiate(prefab, transform.position, transform.rotation);
    }
}