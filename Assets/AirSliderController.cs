using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirSliderController : MonoBehaviour
{
    [SerializeField] private Scrollbar scrollbar;
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private GameObject player;
    private void Awake()
    {
        scrollbar = GetComponent<Scrollbar>();
        EventBus.Current.UpdatePlayerGameObjectEvent += PlayerUpdated;
    }

    public void PlayerUpdated()
    {
        player = EventBus.Current.PlayerReference();
        playerStats = player.GetComponent<PlayerStats>();
        playerStats.UpdateAirAmountEvent += UpdateScrollbar;
        UpdateScrollbar();
    }

    public void UpdateScrollbar()
    {
        scrollbar.size = playerStats.ReturnAirAmount();
    }

    private void OnDestroy()
    {
        EventBus.Current.UpdatePlayerGameObjectEvent -= PlayerUpdated;
    }
}
