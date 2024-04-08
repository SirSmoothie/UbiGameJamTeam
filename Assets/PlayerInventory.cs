using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private static PlayerInventory _current;
    public static PlayerInventory Current { get { return _current; } }
    private void Awake()
    {
        if (_current != null && _current != this)
        {
            Destroy(this.gameObject);
        } else {
            _current = this;
            DontDestroyOnLoad(gameObject);
        } 
        
        EventBus.Current.UpdatePlayerGameObjectEvent += PlayerUpdated;
    }
    public List<FishStatus> caughtFish;
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private float fishValueAmount;

    private void Start()
    {
        //playerStats = GetComponent<PlayerStats>();
    }

    public void PlayerUpdated()
    {
        GameObject playerObject = EventBus.Current.PlayerReference();
        Debug.Log("setting player stats in PlayerInventoryManager");
        Debug.Log(playerObject);
        playerStats = playerObject.transform.GetComponent<PlayerStats>();
        Debug.Log(playerStats);
    }
    public void AddFishToInventory(FishStatus fish)
    {
        caughtFish.Add(fish);
        AddWeightToPlayer(fish.weightOfFish);
        changeFishAmountValue(fish.sizeOfFish);
    }

    public void AddWeightToPlayer(float weight)
    {
        if (playerStats == null) return;
        Debug.Log("adding the weight to the player stats");
        playerStats.ChangeWeightValue(weight);
    }

    public float ReturnFishTotal()
    {
        return fishValueAmount;
    }

    public void changeFishAmountValue(float value)
    {
        fishValueAmount += value;
    }
    
    private void OnDestroy()
    {
        EventBus.Current.UpdatePlayerGameObjectEvent -= PlayerUpdated;
    }
}
