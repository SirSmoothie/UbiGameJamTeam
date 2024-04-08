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

    private void OnMouseUpAsButton()
    {
        if (isStart)
        {
            SceneManager.LoadScene(1);
        }

        if (isCredits)
        {
            SceneManager.LoadScene(2);
        }

        if (isQuit)
        {
            Application.Quit();
        }

    }
    
    
}
