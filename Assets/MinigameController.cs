using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MinigameController : MonoBehaviour
{
    public Fish newFish;
    [SerializeField] private Fish generatedFish;
    public int amountOfFish;
    
    [SerializeField] private int totalPoints;
    [SerializeField] private int totalNegativePoints;
    public GameObject fadeImage;
    public Vector3 posToSpawn;
    public GameObject minigame;
    private bool playing;
    public GameObject shopUI;

    public GameObject player;

    public bool playedToday;
    public int DayPlayed;
    public GameObject interactText;

    private void Start()
    {
        int tempDay;
        tempDay = TimeManager.Current.ReturnDayNumber();
        if (tempDay == DayPlayed)
        {
            playedToday = true;
        }
    }

    private void OnDestroy()
    {
        
    }

    public Fish ReturnFishData()
    {
        return generatedFish;
    }

    public void GenerateNewFish()
    {
        if (generatedFish != null)
        {
            generatedFish.gameObject.SetActive(false);
        }
        if (amountOfFish >= 1)
        {
            amountOfFish--;
            generatedFish = Instantiate(newFish, posToSpawn, Quaternion.identity, transform);
        }
        else
        {
            startTheGame();
        }
    }
    
    public void UpdatePoints(int value)
    {
        totalPoints += value;
    }
    public void UpdateNegativePoints(int value)
    {
        totalNegativePoints += value;
    }

    public void startTheGame()
    {
        StartCoroutine(StartMinigameWithFade());
        playedToday = true;
        DayPlayed = TimeManager.Current.ReturnDayNumber();
    }
    IEnumerator StartMinigameWithFade()
    {
        fadeImage.GetComponent<CanvasGroup>().DOFade(1, 1).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1f);
        StartedMinigame();
        if(amountOfFish > 0) GenerateNewFish();
        playing = !playing;
        minigame.SetActive(playing);
        shopUI.SetActive(!playing);
        if (playing == false)
        {
            player.GetComponent<PlayerModel>().playerControlled = true;
            totalPoints -= totalNegativePoints;
            interactText.SetActive(true);
            if (totalPoints > 0)
            {
                PlayerInventory.Current.changeFishAmountValue(totalPoints);
            }
        }

        if (playing)
        {
            interactText.SetActive(false);
        }
        yield return new WaitForSeconds(1f);
        fadeImage.GetComponent<CanvasGroup>().DOFade(0, 1).SetEase(Ease.Linear);
        
    }
    
    public delegate void PlayingMinigame();

    public event PlayingMinigame PlayingMinigameEvent;

    public void StartedMinigame()
    {
        PlayingMinigameEvent?.Invoke();
    }
}
