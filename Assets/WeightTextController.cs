using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeightTextController : MonoBehaviour
{
    private TextMeshProUGUI textBox;
    private PlayerStats playerStats;
    private float weight = 0;
    private void Start()
    {
        textBox = GetComponent<TextMeshProUGUI>();
        playerStats = EventBus.Current.PlayerReference().GetComponent<PlayerStats>();
        playerStats.UpdateWeightAmountEvent += UpdateText;
        UpdateText();
    }

    public void UpdateText()
    {
        weight = playerStats.ReturnWeightAmount();
        textBox.text = new string(weight+"KG");
    }
}
