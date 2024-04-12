using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MusicPlayerManager : MonoBehaviour
{
    private static MusicPlayerManager _current;
    public static MusicPlayerManager Current { get { return _current; } }
    private void Awake()
    {
        if (_current != null && _current != this)
        {
            Destroy(this.gameObject);
        } else {
            _current = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public bool inWater;
    private void Start()
    {
        
        inWater = EventBus.Current.ReturnInWaterBool();
    }

    public List<AudioClip> MusicClips;
    public List<AudioClip> MusicClipsWater;
    public AudioSource audioSouce;

    public bool musicLoop;
    
    public void StartMusic()
    {
        musicLoop = true;
    }
    private void Update()
    {
        if (musicLoop)
        {
            if (inWater)
            {
                var tempno = Random.Range(0, MusicClipsWater.Count);
                if (!audioSouce.isPlaying)
                {
                    audioSouce.clip = MusicClipsWater[tempno];
                    audioSouce.Play();
                }
            }
            else
            {
                var tempno = Random.Range(0, MusicClips.Count);
                if (!audioSouce.isPlaying)
                {
                    audioSouce.clip = MusicClips[tempno];
                    audioSouce.Play();
                }
            }
        }
    }
}
