using UnityEngine;

public class SlicerController : MonoBehaviour
{
    [SerializeField] private ParticleSystem cutEffect;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<ICuttable>(out var cuttable))
        {
            cutEffect.Play();
            cuttable.OnCut();
        }
    }
}
