using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ArrowkeyGame : MonoBehaviour
{
    public GameObject[] arrowPrefabs; 
    public KeyCode[] arrowKeys; 
    public Transform[] spawnPoints; 
    public TMP_Text scoreText; 
    private int arrowsDestroyed = 0;
    private GameObject previousArrow; 
    private int score = 0; 
    private bool isGameOver = false; 

    private void Start()
    {
        StartCoroutine(SpawnArrows());
    }

    private IEnumerator SpawnArrows()
    {
        while (!isGameOver)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject arrowPrefab = arrowPrefabs[Random.Range(0, arrowPrefabs.Length)];
            
     
            if (previousArrow != null)
                DestroyArrow(previousArrow);


            GameObject arrow = Instantiate(arrowPrefab, spawnPoint.position, Quaternion.identity);
            previousArrow = arrow; 
            
            yield return new WaitForSeconds(3f); 
        }
    }
    
    private void DestroyArrow(GameObject arrow)
    {
        Destroy(arrow);
        arrowsDestroyed++;
        DecreaseScore(); 
        
        if (arrowsDestroyed >= 5)
        {
            GameOver();
        }
        
    }

    public void IncreaseScore()
    {
        score++;
        UpdateScore();
    }

    public void DecreaseScore()
    {
        score -= arrowsDestroyed;
        UpdateScore();
    }
    
    private void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
    
    public void GameOver()
    {
        isGameOver = true;
        Debug.Log("Game Over! Score: " + score);

    }

    
    
}