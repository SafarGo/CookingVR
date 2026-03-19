using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Volume volume;
    private Vignette _vignette;
    private LensDistortion _lens;
    public bool isDebaf;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
        volume.profile.TryGet(out _vignette);
        volume.profile.TryGet(out _lens);
    }


    public void Debaf()
    {
        StartCoroutine(VisualDebaf());
    }

    IEnumerator VisualDebaf()
    {
        _vignette.intensity.value += 0.1f;
        _lens.intensity.value -= 0.2f;
        yield return new WaitForSeconds(1f);
        _vignette.intensity.value -= 0.1f;
        _lens.intensity.value += 0.2f;
    }
}
