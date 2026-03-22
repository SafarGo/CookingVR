using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public struct OrderEntry
{
    public string orderName;
    public GameObject podnosPrefab;
    public int orderScore;
    [Range(0f, 100f)] public float weight;
}

public class OrdersGenerator : MonoBehaviour
{
    [Header("Настройки генератора")]
    [SerializeField] private float timeBetweenOrders;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private List<OrderEntry> orders;

    private void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenOrders);
            SpawnOrder();
        }
    }

    private void SpawnOrder()
    {
        OrderEntry order = GetRandomOrder();
        var go = Instantiate(order.podnosPrefab, spawnPoint.position, spawnPoint.rotation);
        go.GetComponent<PodnosController>().SetIsReady(false);
        go.GetComponent<PodnosController>().SetName(order.orderName);
        go.GetComponent<PodnosController>().SetWeight(order.orderScore);
    }

    private OrderEntry GetRandomOrder()
    {
        float totalWeight = orders.Sum(x => x.weight);
        float random = Random.Range(0f, totalWeight);
        float current = 0f;
        foreach (var order in orders)
        {
            current += order.weight;
            GameManager.instance.maxScore += order.orderScore;
            if (random <= current)
                return order;
        }
        return orders[0];
    }
}