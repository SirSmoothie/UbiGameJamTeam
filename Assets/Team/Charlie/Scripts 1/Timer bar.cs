using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timerbar : MonoBehaviour
{
    public float maxTime = 60f; 
    public Slider timerSlider; 
    public TextMeshProUGUI gameOverText;

    private float currentTime; 
    private bool isGameOver = false;

    void Start()
    {
        currentTime = maxTime; 
        UpdateSliderValue();
    }

    void Update()
    {
        if (!isGameOver)
        {
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime; 
                UpdateSliderValue();
            }
            else
            {
            
                Debug.Log("Time's up!");
                currentTime = 0;
                isGameOver = true;
                GameOver();
            }
        }
    }
    void UpdateSliderValue()
    {
        timerSlider.value = currentTime / maxTime; 
    }

    void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
    }
}