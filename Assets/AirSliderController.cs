using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirSliderController : MonoBehaviour
{
    private Scrollbar scrollbar;
    private PlayerStats playerStats;
    private void Start()
    {
        scrollbar = GetComponent<Scrollbar>();
        playerStats = EventBus.Current.PlayerReference().GetComponent<PlayerStats>();
        playerStats.UpdateAirAmountEvent += UpdateScrollbar;
        UpdateScrollbar();
    }

    public void UpdateScrollbar()
    {
        scrollbar.size = playerStats.ReturnAirAmount();
    }
}
