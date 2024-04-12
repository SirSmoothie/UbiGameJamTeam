using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayTextChanger : MonoBehaviour
{
    public bool ifDay;
    private TextMeshProUGUI text;
    private void Start()
    {
        TimeManager.Current.startUnFadingEvent += ChangeText;
        text = GetComponent<TextMeshProUGUI>();
    }

    public void ChangeText()
    {
        StartCoroutine(ChangeTextRoutine());
    }
    IEnumerator ChangeTextRoutine()
    {
        yield return new WaitForSeconds(0f);
        if (ifDay)
        {
            var temp = TimeManager.Current.ReturnDayNumber();
            text.text = new string(" " +temp);
        }
        else
        {
            var temp = TimeManager.Current.ReturnWeekNumber();
            text.text = new string(" " +temp);
        }
    }
    private void OnDestroy()
    {
        TimeManager.Current.startUnFadingEvent -= ChangeText;
    }
}
