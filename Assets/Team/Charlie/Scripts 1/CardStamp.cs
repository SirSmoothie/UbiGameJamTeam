using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardStamp : MonoBehaviour

{

    public delegate void ScoreUpdatedEventHandler(int updatedScore);

    // Event for score updated
    public static event ScoreUpdatedEventHandler OnScoreUpdated;




    public List<GameObject> chosenFish = new List<GameObject>();

    public int score = 0;


    public void FindFish()
    {
        Fish[] fishes = FindObjectsOfType<Fish>();
        foreach (Fish fish in fishes)
        {
            StampFish(fish.gameObject);
        }
    }

    void StampFish(GameObject fishObject)
    {
        chosenFish.Clear();
        chosenFish.Add(fishObject);

        foreach (GameObject fish in chosenFish)
        {
            Fish fishComponent = fish.GetComponent<Fish>();
            if (fishComponent != null)
            {

                Debug.Log("Is Tail poisoned: " + fishComponent.tail.isPoisoned);
                Debug.Log("Head is poisoned: " + fishComponent.head.isPoisoned);
                Debug.Log("Fin is poisoned: " + fishComponent.fin.isPoisoned);

            }
        }


    }

    public void OnKeepFin(bool isFinPoisoned)
    {
        UpdateScore(isFinPoisoned ? -10 : 10, "kept tail but " + (isFinPoisoned ? "poison" : "not poison"));
    }

    public void RemoveFin(bool isFinPoisoned)
    {
        UpdateScore(isFinPoisoned ? 10 : -10, "removed tail but " + (isFinPoisoned ? "poison" : "not poison"));
    }

    public void OnKeepHead(bool isHeadPoisoned)
    {
        UpdateScore(isHeadPoisoned ? -10 : 10, "kept tail but " + (isHeadPoisoned ? "poison" : "not poison"));
    }

    public void RemoveHead(bool isHeadPoisoned)
    {
        UpdateScore(isHeadPoisoned ? 10 : -10, "removed tail but " + (isHeadPoisoned ? "poison" : "not poison"));
    }

    public void OnKeepTail(bool isTailPoisoned)
    {
        UpdateScore(isTailPoisoned ? -10 : 10, "kept tail but " + (isTailPoisoned ? "poison" : "not poison"));
    }

    public void RemoveTail(bool isTailPoisoned)
    {
        UpdateScore(isTailPoisoned ? 10 : -10, "removed tail but " + (isTailPoisoned ? "poison" : "not poison"));
    }

    private void UpdateScore(int scoreChange, string logMessage)
    {
        score += scoreChange;
        OnScoreUpdated?.Invoke(score);
        Debug.Log(logMessage + " Current score: " + score);
    }


}
