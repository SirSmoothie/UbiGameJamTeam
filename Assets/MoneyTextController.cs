using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyTextController : MonoBehaviour
{
    public TextMeshProUGUI text;

    private void Awake()
    {
        PlayerInventory.Current.MoneyValueChangedEvent += NewUpdate;
    }

    private void Start()
    {
        NewUpdate();
    }

    public void NewUpdate()
    {
        UpdateText(PlayerInventory.Current.ReturnFishTotal());
    }
    public void UpdateText(float NumberToDisplay)
    {
        text.text = new string(": " + NumberToDisplay);
    }

    private void OnDestroy()
    {
        PlayerInventory.Current.MoneyValueChangedEvent -= NewUpdate;
    }
}
