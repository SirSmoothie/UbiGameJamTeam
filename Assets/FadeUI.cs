using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FadeUI : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeSpeed = 1;
    public bool fadeIn;
    [SerializeField] private bool fadeOn;

    public bool IsMoneyUI;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if (IsMoneyUI)
        {
            canvasGroup.alpha = 0;
        }
        else
        {
            canvasGroup.alpha = 1;
            SetFadeTofalse();
        }
        
        TimeManager.Current.startFadingEvent += SetFadeToTrue;
        TimeManager.Current.startUnFadingEvent += SetFadeTofalse;
    }

    void Update()
    {
        //if (fadeOn)
        //{
        //    if (fadeIn)
        //    {
        //        canvasGroup.DOFade(0, fadeSpeed).SetEase(Ease.Linear);
        //    }
        //    else
        //    {
        //        canvasGroup.DOFade(1, fadeSpeed).SetEase(Ease.Linear);
        //    }
        //}
        //if (!fadeOn)
        //{
        //    if (fadeIn)
        //    {
        //        canvasGroup.DOFade(1, fadeSpeed).SetEase(Ease.Linear);
        //    }
        //    else
        //    {
        //        canvasGroup.DOFade(0, fadeSpeed).SetEase(Ease.Linear);
        //    }
        //}
    }

    public void SetFadeToTrue()
    {
        //fadeOn = true;
        canvasGroup.DOFade(1, fadeSpeed).SetEase(Ease.Linear);
    }
    public void SetFadeTofalse()
    {
        //fadeOn = true;
        canvasGroup.DOFade(0, fadeSpeed).SetEase(Ease.Linear);
    }
    public void UpdateFadeOnBool(bool value)
    {
        fadeOn = value;
    }

    private void OnDestroy()
    {
        TimeManager.Current.startFadingEvent -= SetFadeToTrue;
        TimeManager.Current.startUnFadingEvent -= SetFadeTofalse;
    }
}
