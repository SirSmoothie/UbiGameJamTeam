using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public bool isStart;
    public bool isCredits;
    public bool isQuit;

    public SpriteRenderer spriteRenderer;
    public Sprite hSprite;
    public Sprite nhSprite;

    public void OnMouseOver()
    {
        spriteRenderer.sprite = hSprite;
    }

    private void OnMouseExit()
    {
        spriteRenderer.sprite = nhSprite;
    }

    private void OnMouseUpAsButton()
    {
        if (isStart)
        {
            SceneManager.LoadScene(1);
        }

        if (isCredits)
        {
            SceneManager.LoadScene("Credits");
        }

        if (isQuit)
        {
            Application.Quit();
        }

    }
    
    
}
