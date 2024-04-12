using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NetController : MonoBehaviour
{
    public List<GameObject> fishInTrigger;
    public GameObject netObject;
    public bool CanFishAgain;

    public List<AudioClip> NetThrowClip;
    public List<AudioClip> NetCatchClip;

    public AudioSource audioSource;
    public AudioSource audioSource2;
    private void Start()
    {
        CanFishAgain = true;
        netObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fish")
        {
            fishInTrigger.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Fish")
        {
            fishInTrigger.Remove(other.gameObject);
        }
    }

    public GameObject CatchFish()
    {
        if (!CanFishAgain) return null;
        StartCoroutine(CatchFishAnimationthing());
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        if (audioSource2.isPlaying)
        {
            audioSource2.Stop();
        }
        var ThorwNo = Random.Range(0, NetThrowClip.Count);
        audioSource.clip = NetThrowClip[ThorwNo];
        audioSource.Play();
        if(fishInTrigger.Count >= 1)
        {
            var tempNo = Random.Range(0, NetCatchClip.Count);
            audioSource2.clip = NetCatchClip[tempNo];
            audioSource2.Play();
            if (fishInTrigger[0] == null) return null;
            var fishToSendOff = fishInTrigger[0];
            fishToSendOff.SetActive(false);
            fishInTrigger.Remove(fishToSendOff);
            return fishToSendOff;
        }
        return null;
    }

    IEnumerator CatchFishAnimationthing()
    {
        GameObject player = EventBus.Current.PlayerReference();
        player.GetComponent<PlayerModel>().playerControlled = false;
        player.GetComponent<PlayerModel>().currentDirection = Vector3.zero;
        CanFishAgain = false;
        netObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        netObject.SetActive(false);
        player.GetComponent<PlayerModel>().playerControlled = true;
        player.GetComponent<PlayerModel>().currentDirection = Vector3.zero;
        CanFishAgain = true;
    }
}
