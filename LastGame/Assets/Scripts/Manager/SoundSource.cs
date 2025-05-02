using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundSource : MonoBehaviour
{
    private AudioSource audioSource;

    public void Play(AudioClip clip, float soundEffectVloume, float soundEffectPitchVariance)
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
        
        CancelInvoke();
        audioSource.clip = clip;
        audioSource.volume = soundEffectVloume;
        audioSource.Play();
        audioSource.pitch = 1f + Random.Range(-soundEffectPitchVariance, soundEffectPitchVariance);
        
        Invoke("Disable", clip.length + 2);
    }

    private void Disable()
    {
        audioSource?.Stop();
        Destroy(this.gameObject);
    }
}
