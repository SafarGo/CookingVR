using System.Collections;
using UnityEngine;

public class DebufController : MonoBehaviour
{
    public AudioSource debafSound;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Slicer"))
        {
            GameManager.instance.isDebaf = true;
            Destroy(other.gameObject);
            StartCoroutine(DebugDelay());
        }
    }

    IEnumerator DebugDelay()
    {
        debafSound.Play();
        yield return new WaitForSeconds(6f);
        GameManager.instance.isDebaf = false;
        debafSound.Stop();
    }
}
