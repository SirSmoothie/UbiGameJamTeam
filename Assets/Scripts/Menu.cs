using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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

    public GameObject FadeUI;

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

            StartCoroutine(LoadSelectedScene(1));
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

    IEnumerator LoadSelectedScene(int number)
    {
        FadeUI.GetComponent<CanvasGroup>().DOFade(1, 2).SetEase(Ease.Linear);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(1);
    }
}
