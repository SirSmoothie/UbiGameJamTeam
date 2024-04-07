using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    public KeyCode arrowKey;  
    public float timeBeforeDisappear = 3f; 
    private float timer = 0f; 
    private bool isKeyPressed = false; 
    public ArrowkeyGame arrowGameManager; 

    void Start()
    {
        arrowGameManager = GameObject.FindObjectOfType<ArrowkeyGame>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        
        if (transform.position.y <= -5f || timer >= timeBeforeDisappear)
        {
            Debug.Log("Missed!");
        }
        
        
        if (!isKeyPressed && Input.GetKeyDown(arrowKey))
        {
        
            isKeyPressed = true;
            arrowGameManager.IncreaseScore();
            Destroy(gameObject);
            
            Debug.Log("Hit correct arrow!");
            
        
        }
    }
    
}