using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PodnosController : MonoBehaviour
{
    [Header("Настройки подноса")]
    [SerializeField] private string nameOfOrder;
    [SerializeField] private bool isOrderReady;
    [SerializeField] TMP_Text textForname;
    [SerializeField] Rigidbody rb;
    private Dictionary<string, int> productsToComplete = new Dictionary<string, int>();
    private Dictionary<string, int> productsAdded = new Dictionary<string, int>();
    public int score;
    public AudioSource putSound;
    public string GetName() => nameOfOrder;
    public int SetWeight(int value) { score = value; return score; }
    public bool GetIsReady() => isOrderReady;
    public void SetIsReady(bool value) { isOrderReady = value; }

    public void SetName(string name)
    {
        nameOfOrder = name;
        productsToComplete.Clear();
        productsAdded.Clear();

        if (name == "Pelmeni")
        {
            productsToComplete["Pelmeni"] = 1;
        }
        if (name == "Makaroni")
        {
            productsToComplete["Makaroni"] = 1;
            productsToComplete["Farsh"] = 1;
        }
        if (name == "Holodec")
        {
            productsToComplete["Meat"] = 1;
            productsToComplete["Zhelatin"] = 1;
        }
        if (name == "Salad")
        {
            productsToComplete["Tomato"] = 1;
            productsToComplete["Picul"] = 1;
            productsToComplete["Olives"] = 1;
        }
        foreach (var key in productsToComplete.Keys)
        {
            productsAdded[key] = 0;
        }

        textForname.text = nameOfOrder;
    }

    private void OnTriggerEnter(Collider other)
    {
        string tag = other.tag;

        if (productsToComplete.ContainsKey(tag))
        {
            if (productsAdded[tag] < productsToComplete[tag] && other.GetComponent<BaseItem>().isReady)
            {
                putSound.Play();
                Debug.Log($"Added to podnos {tag}");
                productsAdded[tag]++;
                Destroy(other.gameObject);
            }
        }
    }

    private void Update()
    {
        bool ready = true;
        foreach (var key in productsToComplete.Keys)
        {
            if (productsAdded[key] < productsToComplete[key])
            {
                ready = false;
                break;
            }
        }
        isOrderReady = ready;
    }
}
