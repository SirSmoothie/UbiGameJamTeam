using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FishController : MonoBehaviour, ICatchable
{
    public int sizeOfFish = 1;
    public FishStatus fishStatus; 
    public void CatchFish()
    {
        //EventBus.Current.ChangeFoodCaughtAmount(sizeOfFish);
        gameObject.SetActive(false);
    }

    public FishStatus ReturnFishStats()
    {
        return fishStatus;
    }
    private void Awake()
    {
        transform.eulerAngles = new Vector3(0,0,Random.Range(0, 360));
    }
}
