using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardStamp : MonoBehaviour

{
    public delegate void ScoreUpdatedEventHandler(int updatedScore);

    public FishMarket fishMarket;
    public static event ScoreUpdatedEventHandler OnScoreUpdated;
    public List<GameObject> chosenFish = new List<GameObject>();
    public int score = 0;
    public TextMeshProUGUI infoText;

    private Dictionary<string, bool> fishParts = new Dictionary<string, bool>();
    private int trueCount = 0;

    void Start()
    {
        fishParts.Add("finKept", false);
        fishParts.Add("finRemoved", false);
        fishParts.Add("headKept", false);
        fishParts.Add("headRemoved", false);
        fishParts.Add("tailKept", false);
        fishParts.Add("tailRemoved", false);
    }

    void CheckTrueCount()
    {
        trueCount = 0;
        foreach (KeyValuePair<string, bool> entry in fishParts)
        {
            if (entry.Value)
                trueCount++;
        }

        if (trueCount >= 3)
        {
            NextFish();
            ResetFishParts();
        }
    }
    void ResetFishParts()
    {
        List<string> keysToReset = new List<string>();
        
        foreach (var pair in fishParts)
        {
            if (pair.Value)
            {
                keysToReset.Add(pair.Key);
            }
        }
        
        foreach (string key in keysToReset)
        {
            fishParts[key] = false;
        }
    }
    
    
    
    public void OnKeepPart(string part)
    {
        GameObject fishGameObject = FindFish();
        if (fishGameObject != null && !fishParts[part + "Kept"] && !fishParts[part + "Removed"])
        {
            Fish fishComponent = fishGameObject.GetComponent<Fish>();
            int scoreChange = 0;
            string partType = "";
            switch (part)
            {
                case "fin":
                    scoreChange = fishComponent.body.isPoisoned ? -10 : 10;
                    partType = "fin";
                    break;
                case "head":
                    scoreChange = fishComponent.head.isPoisoned ? -10 : 10;
                    partType = "head";
                    break;
                case "tail":
                    scoreChange = fishComponent.tail.isPoisoned ? -10 : 10;
                    partType = "tail";
                    break;
            }

            UpdateScore(scoreChange,
                $"Kept fish with {(fishComponent.body.isPoisoned ? "poisoned" : "healthy")} {partType}.");
            fishParts[part + "Kept"] = true;
            CheckTrueCount();
        }
    }

    public void RemovePart(string part)
    {
        GameObject fishGameObject = FindFish();
        if (fishGameObject != null && !fishParts[part + "Kept"] && !fishParts[part + "Removed"])
        {
            Fish fishComponent = fishGameObject.GetComponent<Fish>();
            int scoreChange = 0;
            string partType = "";
            switch (part)
            {
                case "fin":
                    scoreChange = fishComponent.body.isPoisoned ? 10 : -10;
                    partType = "fin";
                    break;
                case "head":
                    scoreChange = fishComponent.head.isPoisoned ? 10 : -10;
                    partType = "head";
                    break;
                case "tail":
                    scoreChange = fishComponent.tail.isPoisoned ? 10 : -10;
                    partType = "tail";
                    break;
            }

            UpdateScore(scoreChange,
                $"Removed {partType} but {(fishComponent.body.isPoisoned ? "poisoned" : "not poisoned")}");
            fishParts[part + "Removed"] = true;
            CheckTrueCount();
        }
    }

    public GameObject FindFish()
    {
        Fish[] fishes = FindObjectsOfType<Fish>();
        foreach (Fish fish in fishes)
        {
            return fish.gameObject;
        }

        return null;
    }

    private void UpdateScore(int scoreChange, string logMessage)
    {
        score += scoreChange;
        OnScoreUpdated?.Invoke(score);
        Debug.Log(logMessage + " Current score: " + score);
    }

    public void NextFish()
    {
  
        if (fishMarket != null)
        {
            fishMarket.GoToNextFish();
            Debug.Log("go to next fish");
        }
    }
}


