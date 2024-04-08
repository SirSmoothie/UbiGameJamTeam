using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeightTextController : MonoBehaviour
{
    private TextMeshProUGUI textBox;
    [SerializeField]private PlayerStats playerStats;
    private GameObject player;
    [SerializeField]private float weight = 0;
    private void Awake()
    {
        textBox = GetComponent<TextMeshProUGUI>();
        EventBus.Current.UpdatePlayerGameObjectEvent += PlayerUpdated;
    }

    public void PlayerUpdated()
    {
        Debug.Log("Updated Player");
        player = EventBus.Current.PlayerReference();
        playerStats = player.GetComponent<PlayerStats>();
        playerStats.UpdateWeightAmountEvent += UpdateText;
        UpdateText();
    }

    public void UpdateText()
    {
        weight = playerStats.ReturnWeightAmount();
        textBox.text = new string(weight+"KG");
    }

    private void OnDestroy()
    {
        playerStats.UpdateWeightAmountEvent -= UpdateText;
        EventBus.Current.UpdatePlayerGameObjectEvent -= PlayerUpdated;
    }
}
