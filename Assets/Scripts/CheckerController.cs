using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CheckerController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Podnos"))
        {
            PodnosController podnos = other.GetComponent<PodnosController>();
            if (podnos != null && podnos.GetIsReady())
            {
                Debug.Log("Заказ готов: " + podnos.GetName());
                GameManager.instance.score += podnos.score;
            }
            Destroy(other.gameObject);
        }
    }
}
