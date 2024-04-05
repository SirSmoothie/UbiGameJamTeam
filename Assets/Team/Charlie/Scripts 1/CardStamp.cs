using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardStamp : MonoBehaviour
{
    private bool finKept = false;
    private bool finRemoved = false;

    private bool headKept = false;
    private bool headRemoved = false;

    private bool tailKept = false;
    private bool tailRemoved = false;
    
    public delegate void ScoreUpdatedEventHandler(int updatedScore);
    public static event ScoreUpdatedEventHandler OnScoreUpdated;
    public List<GameObject> chosenFish = new List<GameObject>();
    public int score = 0;
    public TextMeshProUGUI infoText;


    public GameObject FindFish()
    {
        Fish[] fishes = FindObjectsOfType<Fish>();
        foreach (Fish fish in fishes)
        {
            // Return the GameObject of the first fish found
            return fish.gameObject;
        }

        return null; // Return null if no fish is found
    }

    void StampFish(GameObject fishObject)
    {
        chosenFish.Clear();
        chosenFish.Add(fishObject);
    }

    public void OnKeepFin()
    {
        GameObject fishGameObject = FindFish();
        if (fishGameObject != null && !finKept && !finRemoved)
        {
            Fish fishComponent = fishGameObject.GetComponent<Fish>();
            UpdateScore(fishComponent.fin.isPoisoned ? -10 : 10,
                "Kept fish with " + (fishComponent.fin.isPoisoned ? "poisoned" : "healthy") + " fin.");
            finKept = true;
        }
    }

    public void RemoveFin()
    {
        GameObject fishGameObject = FindFish();
        if (fishGameObject != null && !finKept && !finRemoved)
        {
            Fish fishComponent = fishGameObject.GetComponent<Fish>();
            UpdateScore(fishComponent.fin.isPoisoned ? 10 : -10,
                "Removed fin but " + (fishComponent.fin.isPoisoned ? "poisoned" : "not poisoned"));
            finRemoved = true;
        }
    }

    public void OnKeepHead()
    {
        GameObject fishGameObject = FindFish();
        if (fishGameObject != null && !headKept && !headRemoved)
        {
            Fish fishComponent = fishGameObject.GetComponent<Fish>();
            UpdateScore(fishComponent.head.isPoisoned ? -10 : 10,
                "Kept fish with " + (fishComponent.head.isPoisoned ? "poisoned" : "healthy") + " head.");
            headKept = true;
        }
    }

    public void RemoveHead()
    {
        GameObject fishGameObject = FindFish();
        if (fishGameObject != null && !headKept && !headRemoved)
        {
            Fish fishComponent = fishGameObject.GetComponent<Fish>();
            UpdateScore(fishComponent.head.isPoisoned ? 10 : -10,
                "Removed head but " + (fishComponent.head.isPoisoned ? "poisoned" : "not poisoned"));
            headRemoved = true;
        }
    }

    public void OnKeepTail()
    {
        GameObject fishGameObject = FindFish();
        if (fishGameObject != null && !tailKept && !tailRemoved)
        {
            Fish fishComponent = fishGameObject.GetComponent<Fish>();
            UpdateScore(fishComponent.tail.isPoisoned ? -10 : 10,
                "Kept fish with " + (fishComponent.tail.isPoisoned ? "poisoned" : "healthy") + " tail.");
            tailKept = true;
        }
    }

    public void RemoveTail()
    {
        GameObject fishGameObject = FindFish();
        if (fishGameObject != null && !tailKept && !tailRemoved)
        {
            Fish fishComponent = fishGameObject.GetComponent<Fish>();
            UpdateScore(fishComponent.tail.isPoisoned ? 10 : -10,
                "Removed tail but " + (fishComponent.tail.isPoisoned ? "poisoned" : "not poisoned"));
            tailRemoved = true;
        }
    }
    
    private void UpdateScore(int scoreChange, string logMessage)
    {
        score += scoreChange;
        OnScoreUpdated?.Invoke(score);
        Debug.Log(logMessage + " Current score: " + score);
    }
}