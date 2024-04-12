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
        
    }
    public List<FishStatus> caughtFish;
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private GameObject player;
    [SerializeField] private float fishValueAmount;

    private void Start()
    {
        EventBus.Current.UpdatePlayerGameObjectEvent += PlayerUpdated;
        EventBus.Current.SceneUpdatedEvent += SceneUpdated;
        TimeManager.Current.EndOfWeekEvent += EvaluateFood;
    }

    public void EvaluateFood()
    {
        int weekNumber = TimeManager.Current.ReturnWeekNumber();
        if (fishValueAmount >= weekNumber * 5)
        {
            fishValueAmount -= weekNumber * 5;
            TimeManager.Current.SurvivedWeek();
        }
    }

    public void SceneUpdated()
    {
        RemoveAllFish();
    }
    public void RemoveAllFish()
    {
        caughtFish = new List<FishStatus>();
    }
    public void PlayerUpdated()
    {
        player = EventBus.Current.PlayerReference();
        Debug.Log("setting player stats in PlayerInventoryManager");
        Debug.Log(player);
        playerStats = player.GetComponent<PlayerStats>();
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
        Debug.Log("Trying to add the weight to the player stats");
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
        TextUpdated();
    }

    public delegate void MoneyValueChanged();
    public event MoneyValueChanged MoneyValueChangedEvent;
    public void TextUpdated()
    {
        MoneyValueChangedEvent?.Invoke();
    }
    
    private void OnDestroy()
    {
        EventBus.Current.UpdatePlayerGameObjectEvent -= PlayerUpdated;
        EventBus.Current.SceneUpdatedEvent -= SceneUpdated;
    }
}
