using System.Collections;
using UnityEngine;

public class DebufController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.isDebaf = true;
        Destroy(other.gameObject);
        StartCoroutine(DebugDelay());
    }

    IEnumerator DebugDelay()
    {
        yield return new WaitForSeconds(6f);
        GameManager.instance.isDebaf = false;
    }
}
