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


        void OnDisable()
        {
            CardStamp.OnScoreUpdated -= HandleScoreUpdated;
        }

  
        void HandleScoreUpdated(int updatedScore)
        {
            if (scoreText != null)
            {
                scoreText.text = "Score: " + updatedScore;
            }
        }
        
        
        

    
}
