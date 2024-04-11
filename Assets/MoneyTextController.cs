using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyTextController : MonoBehaviour
{
    public TextMeshProUGUI text;

    private void Start()
    {
        PlayerInventory.Current.MoneyValueChangedEvent += NewUpdate;
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
