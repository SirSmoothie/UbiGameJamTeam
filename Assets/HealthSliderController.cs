using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthSliderController : MonoBehaviour
{
    private Scrollbar scrollbar;
    private PlayerStats playerStats;
    private GameObject player;
    private void Awake()
    {
        scrollbar = GetComponent<Scrollbar>();
        EventBus.Current.UpdatePlayerGameObjectEvent += PlayerUpdated;
    }

    public void PlayerUpdated()
    {
        player = EventBus.Current.PlayerReference();
        playerStats = player.GetComponent<PlayerStats>();
        playerStats.UpdateHealthAmountEvent += UpdateScrollbar;
        UpdateScrollbar();
    }
    public void UpdateScrollbar()
    {
        scrollbar.size = playerStats.ReturnHealthAmount();
    }

    private void OnDestroy()
    {
        EventBus.Current.UpdatePlayerGameObjectEvent -= PlayerUpdated;
    }
}
