using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Volume volume;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text score_text;
    [SerializeField] private TMP_Text maxScore_text;
    private Vignette _vignette;
    private LensDistortion _lens;
    public bool isDebaf;
    public int score;
    public int maxScore;
    public float timeOfSession;
    public bool isTrashopened;
    public List<GameObject> sockets;

    public static GameManager instance;

    private void Awake()
    {
        score = 0;
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

    void Update()
    {
        timeOfSession -= Time.deltaTime;
        timerText.text = $"Время: {timeOfSession:F1} сек";
        score_text.text = $"Счет: {score}";
        maxScore_text.text = $"Макс. счет: {maxScore}";
        if (timeOfSession <= 0)
        {
            Debug.Log($"Игра окончена! Ваш счет: {score}");
            if (score/maxScore >=0.75f)
            {
                Debug.Log("Отличный результат! Вы справились с задачей!");
            }
            else
            {
                Debug.Log("К сожалению, вы не достигли цели. Попробуйте снова!");
            }
                enabled = false; // Остановить обновление GameManager
        }
        if (isDebaf)
        {
            for(int i = 0; i<sockets.Count; i++)
            {
                sockets[i].SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < sockets.Count; i++)
            {
                sockets[i].SetActive(true);
            }
        }
    }
}
