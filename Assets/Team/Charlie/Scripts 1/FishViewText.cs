using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FishViewText : MonoBehaviour
{
    public TextMeshProUGUI scoreText; 

        void OnEnable()
        {
            CardStamp.OnScoreUpdated += HandleScoreUpdated;
        }

        // Unsubscribe from the event
        void OnDisable()
        {
            CardStamp.OnScoreUpdated -= HandleScoreUpdated;
        }

        // Example method to handle score updated event
        void HandleScoreUpdated(int updatedScore)
        {
            if (scoreText != null)
            {
                scoreText.text = "Score: " + updatedScore;
            }
        }
        
        
        

    
}
