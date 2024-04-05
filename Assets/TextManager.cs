using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI textObject;
    public GameObject textBox;
    // private float timer = 0f;
    // private bool timerOn;

    private void Start()
    {
        DisplayTextBox(false);
    }

    public void TextToDisplay(string textToDisplay)
    {
        DisplayTextBox(true);
        textObject.text = textToDisplay;
        // timer = TimeToDisplay;
        // timerOn = true;
    }

    public void DisplayTextBox(bool value)
    {
        textBox.SetActive(value);
    }

    // public void Update()
    // {
    //     if (timer > 0)
    //     {
    //         timer -= Time.deltaTime;
    //     }
    //
    //     if (timerOn && timer <= 0)
    //     {
    //         timerOn = false;
    //         DisplayTextBox(false);
    //     }
    // }
}
