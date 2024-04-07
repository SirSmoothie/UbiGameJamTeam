using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour, ICatchable
{
    public int sizeOfFish = 1;   
    public void CatchFish()
    {
        EventBus.Current.ChangeFoodCaughtAmount(sizeOfFish);
        gameObject.SetActive(false);
    }
}
