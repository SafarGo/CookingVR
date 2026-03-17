using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CuttableItem : BaseItem, ICuttable
{
    [Header("Настройки нарезки")]
    [SerializeField] private Slider cutSlider;
    [SerializeField] private float cutAmountForOneHit = 0.25f;
    [SerializeField] private List<GameObject> parts;
 
    public float CutProgress { get; private set; }

    void Start()
    {
        cutSlider.gameObject.SetActive(false);
    }

    public void OnCut()
    {
        cutSlider.gameObject.SetActive(true);
        CutProgress += cutAmountForOneHit;
        cutSlider.value = CutProgress;
        if (CutProgress >= 1f)
        {
            OnFullCut();
        }
    }

    void OnFullCut()
    {
        Debug.Log("Item fully cut!");
        for(int i = 0; i <parts.Count; i++)
        {
            Instantiate(parts[i], transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
