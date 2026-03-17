using TMPro;
using UnityEngine;

public class PodnosController : MonoBehaviour
{
    [Header("Настройки подноса")]
    [SerializeField] private string nameOfOrder;
    [SerializeField] private bool isOrderReady;
    [SerializeField] TMP_Text textForname;
    [SerializeField] Rigidbody rb;

    public string GetName() => nameOfOrder;
    public bool GetIsReady() => isOrderReady;
    public void SetIsReady(bool value) { isOrderReady = value; }

    public void SetName(string name)
    {
        nameOfOrder = name;
        textForname.text = nameOfOrder;
    }
}