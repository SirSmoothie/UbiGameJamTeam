using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public MinigameController minigameController;
    
    [SerializeField] private bool head;
    [SerializeField] private bool headSet;
    [SerializeField] private GameObject greenTickHead;
    [SerializeField] private GameObject redTickHead;
    [SerializeField] private bool body;
    [SerializeField] private bool bodySet;
    [SerializeField] private GameObject greenTickBody;
    [SerializeField] private GameObject redTickBody;
    [SerializeField] private bool tail;
    [SerializeField] private bool tailSet;
    [SerializeField] private GameObject greenTickTail;
    [SerializeField] private GameObject redTickTail;
    private bool routineActive;

    public StampController stamp;
    public void SetHead()
    {
        if (routineActive)
        {
            StopCoroutine(DelayedEvaluate());
            routineActive = false;
        }
        headSet = false;
        if (stamp.greenStampSide)
        {
            head = true;
        }
        if(!stamp.greenStampSide)
        {
            head = false;
        }
        headSet = true;
    }
    public void SetBody()
    {
        if (routineActive)
        {
            StopCoroutine(DelayedEvaluate());
            routineActive = false;
        }
        bodySet = false;
        if (stamp.greenStampSide)
        {
            body = true;
        }
        if(!stamp.greenStampSide)
        {
            body = false;
        }
        bodySet = true;
    }
    public void SetTail()
    {
        if (routineActive)
        {
            StopCoroutine(DelayedEvaluate());
            routineActive = false;
        }
        tailSet = false;
        if (stamp.greenStampSide)
        {
            tail = true;
        }
        if(!stamp.greenStampSide)
        {
            tail = false;
        }
        tailSet = true;
    }

    private void Update()
    {
        if (!headSet)
        {
            greenTickHead.SetActive(false);
            redTickHead.SetActive(false);
        }
        if (!bodySet)
        {
            greenTickBody.SetActive(false);
            redTickBody.SetActive(false);
        }
        if (!tailSet)
        {
            greenTickTail.SetActive(false);
            redTickTail.SetActive(false);
        }
        if (headSet)
        {
            if (head)
            {
                greenTickHead.SetActive(true);
                redTickHead.SetActive(false);
            }
            else
            {
                greenTickHead.SetActive(false);
                redTickHead.SetActive(true);
            }
        }
        if (bodySet)
        {
            if (body)
            {
                greenTickBody.SetActive(true);
                redTickBody.SetActive(false);
            }
            else
            {
                greenTickBody.SetActive(false);
                redTickBody.SetActive(true);
            }
        }
        if (tailSet)
        {
            if (tail)
            {
                greenTickTail.SetActive(true);
                redTickTail.SetActive(false);
            }
            else
            {
                greenTickTail.SetActive(false);
                redTickTail.SetActive(true);
            }
        }
        if (headSet && bodySet && tailSet && !routineActive)
        {
            routineActive = true;
            StartCoroutine(DelayedEvaluate());
        }
    }

    IEnumerator DelayedEvaluate()
    {
        yield return new WaitForSeconds(1.5f);
        EvaluateFish();
    }
    public void EvaluateFish()
    {
        var negativePoints = 0;
        var points = 0;
        Fish newFish = minigameController.ReturnFishData();
        
        //This is if you keep a bad part
        if (newFish.head.isPoisoned)
        {
            if (head)
            {
                negativePoints += 1;
            }
        }
        if (newFish.body.isPoisoned)
        {
            if (body)
            {
                negativePoints += 1;
            }
        }
        if (newFish.tail.isPoisoned)
        {
            if (tail)
            {
                negativePoints += 1;
            }
        }
        
        //This is if you keep a good part
        if (newFish.head.isPoisoned == false)
        {
            if (head)
            {
                points += 1;
            }
        }
        if (newFish.body.isPoisoned == false)
        {
            if (body)
            {
                points += 1;
            }
        }
        if (newFish.tail.isPoisoned == false)
        {
            if (tail)
            {
                points += 1;
            }
        }

        headSet = false;
        head = false;
        bodySet = false;
        body = false;
        tailSet = false;
        tail = false;

        minigameController.UpdatePoints(points);
        minigameController.UpdateNegativePoints(negativePoints);
        minigameController.GenerateNewFish();
    }
}
