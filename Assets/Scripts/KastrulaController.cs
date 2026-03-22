using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct BoilRecipe
{
    public string inputTag;
    public GameObject outputPrefab;
}

public class KastrulaController : BaseItem
{
    [SerializeField] private Slider slider;
    [SerializeField] private float timeToBoil;
    [SerializeField] private bool isOnPlita;
    [SerializeField] private List<BoilRecipe> recipes;
    public bool isReadyToBoil;
    private GameObject newObj;
    private string currentTag;

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if(other.CompareTag("Magnit"))
        {
            isOnPlita = true;
        }
        BoilRecipe recipe = recipes.FirstOrDefault(r => r.inputTag == other.tag);
        if (recipe.outputPrefab == null) return;

        isReadyToBoil = false;
        newObj = recipe.outputPrefab;
        currentTag = other.tag;
        StartCoroutine(Boil(other.gameObject));
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Magnit"))
        {
            isOnPlita = false;
        }
    }


    private void Update()
    {
        OnMagnit();
    }
    IEnumerator Boil(GameObject other)
    {
        if (isOnPlita && recipes.Any(r => r.inputTag == currentTag))
        {
            Destroy(other);
            slider.gameObject.SetActive(true);
            float timer = 0;
            while (timer < timeToBoil)
            {
                timer += Time.deltaTime;
                slider.value = timer / timeToBoil;
                yield return null;
            }
            Debug.Log("Boiled");
            isReadyToBoil = true;
            slider.gameObject.SetActive(false);
            Instantiate(newObj, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            newObj = null;
            currentTag = null;
        }
    }
}
