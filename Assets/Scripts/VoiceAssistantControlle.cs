using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class VoiceAssistantControlle : MonoBehaviour
{
    public AudioSource[] sources;
    private int current = 0;

    private void Start()
    {
        sources[current].Play();
    }

    private void Update()
    {
        if (!sources[current].isPlaying && current < sources.Length - 1)
        {
            current++;
            sources[current].Play();
        }
    }
}
