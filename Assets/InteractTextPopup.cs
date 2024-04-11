using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class InteractTextPopup : MonoBehaviour
{
    private bool textOn;
    public bool textFade;
    public GameObject text;
    public float fadeTime;

    public PlayerModel playerModel;
    private void Start()
    {
        playerModel = GetComponent<PlayerModel>();
        text.GetComponent<CanvasGroup>().alpha = 0f;
    }

    private void Update()
    {
        GameObject thing = playerModel?.CurrentTrigger;
        if (thing == null)
        {
            RemoveText();
            return;
        }
        IInteractable interactableObject = thing.transform.GetComponent<IInteractable>();
        if (interactableObject != null)
        {
            ShowText();
        }
        else
        {
            RemoveText();
        }
    }

    public void ShowText()
    {
        text.GetComponent<CanvasGroup>().DOFade(1, fadeTime).SetEase(Ease.Linear);
    }

    public void RemoveText()
    {
        text.GetComponent<CanvasGroup>().DOFade(0, fadeTime).SetEase(Ease.Linear);
    }
}
