using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FadeUI : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeSpeed;
    public bool fadeIn;
    [SerializeField] private bool fadeOn;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
    }

    void Update()
    {
        if (fadeOn)
        {
            if (fadeIn)
            {
                canvasGroup.DOFade(0, fadeSpeed);
            }
            else
            {
                canvasGroup.DOFade(1, fadeSpeed);
            }
        }
        if (!fadeOn)
        {
            if (fadeIn)
            {
                canvasGroup.DOFade(1, fadeSpeed);
            }
            else
            {
                canvasGroup.DOFade(0, fadeSpeed);
            }
        }
    }

    public void UpdateFadeOnBool(bool value)
    {
        fadeOn = value;
    }
}
