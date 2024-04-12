using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FootStepAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public List<AudioClip> footstepAudio;
    public bool playingAudio;
    
    public AudioClip fallMusic;
    public AudioClip crashClip;
    public bool isFallPlaying;
    public void PlayCrash()
    {
        isFallPlaying = true;
        StopFootstepAudio();
        audioSource.clip = crashClip;
        audioSource.pitch = 1f;
        audioSource.volume = 0.3f;
        audioSource.Play();
        StartCoroutine(CrashTimer());
    }
    public void PlayFall()
    {
        StopFootstepAudio();
        audioSource.clip = fallMusic;
        audioSource.pitch = 1f;
        audioSource.volume = 0.3f;
        audioSource.Play();
    }
    
    
    public void PlayFootStepAudio()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.volume = 0.14f;
            audioSource.pitch = 0.69f;
            playingAudio = true;
            var tempNo = Random.Range(0, footstepAudio.Count);
            audioSource.clip = footstepAudio[tempNo];
            audioSource.Play();
        }
    }

    private void Update()
    {
        if (!audioSource.isPlaying && playingAudio)
        {
            PlayFootStepAudio();
        }
    }

    IEnumerator CrashTimer()
    {
        yield return new WaitForSeconds(10f);
        MusicPlayerManager.Current.StartMusic();
    }

    public void StopFootstepAudio()
    {
        if (playingAudio)
        {
            playingAudio = false;
            audioSource.Stop();
        }
    }
}
