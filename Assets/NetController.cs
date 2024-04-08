using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetController : MonoBehaviour
{
    public List<GameObject> fishInTrigger;
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
        if(fishInTrigger.Count >= 1)
        {
            if (fishInTrigger[0] == null) return null;
            var fishToSendOff = fishInTrigger[0];
            fishToSendOff.SetActive(false);
            fishInTrigger.Remove(fishToSendOff);
            return fishToSendOff;
        }

        return null;
    }
}
