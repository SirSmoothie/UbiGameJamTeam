using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthSliderController : MonoBehaviour
{
    private Scrollbar scrollbar;
    private PlayerStats playerStats;
    private void Start()
    {
        scrollbar = GetComponent<Scrollbar>();
        playerStats = EventBus.Current.PlayerReference().GetComponent<PlayerStats>();
        playerStats.UpdateHealthAmountEvent += UpdateScrollbar;
        UpdateScrollbar();
    }

    public void UpdateScrollbar()
    {
        scrollbar.size = playerStats.ReturnHealthAmount();
    }
}
