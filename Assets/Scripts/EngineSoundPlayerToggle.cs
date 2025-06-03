using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSoundPlayerToggle : MonoBehaviour
{
    public AudioSource engineAudioSource;
    private bool isPlaying = false;

    public void ToggleEngineSound()
    {
        if (isPlaying)
            StopEngineSound();
        else
            PlayEngineSound();

        isPlaying = !isPlaying;
    }

    public void PlayEngineSound()
    {
        if (engineAudioSource == null) return;
        engineAudioSource.Play();
    }

    public void StopEngineSound()
    {
        if (engineAudioSource == null) return;
        engineAudioSource.Stop();
        engineAudioSource.time = 0f; 
    }
}

