using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InspectObject : MonoBehaviour, IInteractable
{
    public List<Description> descriptions;
    public List<Description> descriptionsReRun;
    public int bookmark;
    public int bookmark2;
    public float timer = 1;
    public bool paused;
    
    public bool IsTalking;
    public bool Skippable;
    public bool listRollOver;
    public bool AutoTalk;
    
    public bool secondRunning;
    public bool hasSecondDialog;
    
    public bool dialogRepeats;

    public GameObject textToToggle;

    public int endOfDialogInt;

    private void Start()
    {
        ShowInteractText(false);
    }

    public void Interacted(GameObject Interactor)
    {
        ShowInteractText(false);
        if (!paused)
        {
            #region FirstDialog

            if (!secondRunning)
            {
                endOfDialogInt = descriptions.Count;
                if (bookmark >= descriptions.Count)
                {
                    IsTalking = false;
                    return;
                }

                if (bookmark2 >= descriptions[bookmark].statements.Count && !listRollOver)
                {
                    IsTalking = false;
                    return;
                }

                if (IsTalking && Skippable) bookmark2++;
                IsTalking = true;
                if (bookmark2 >= descriptions[bookmark].statements.Count && listRollOver)
                {
                    IsTalking = false;
                    timer = 1;
                    bookmark++;
                    bookmark2 = 0;
                    Interacted(null);
                }
                else if (bookmark <= descriptions.Count)
                {
                    DisplayDescription(descriptions);
                    timer = descriptions[bookmark].statements[bookmark2].timeTillNextText;
                }
            }

            #endregion

            #region SecondDialog

            if (secondRunning)
            {
                endOfDialogInt = descriptionsReRun.Count;
                if (IsTalking && Skippable) bookmark2++;
                IsTalking = true;
                if (bookmark >= descriptionsReRun.Count )
                {
                    IsTalking = false;
                    return;
                }
                if (bookmark2 >= descriptionsReRun[bookmark].statements.Count && !listRollOver)
                {
                    IsTalking = false;
                    return;
                }
                if (bookmark2 >= descriptionsReRun[bookmark].statements.Count && listRollOver)
                {
                    IsTalking = false;
                    timer = 1;
                    bookmark++;
                    bookmark2 = 0;
                    Interacted(null);
                }
                else if (bookmark <= descriptionsReRun.Count)
                {
                    DisplayDescription(descriptionsReRun);
                    timer = descriptionsReRun[bookmark].statements[bookmark2].timeTillNextText;
                }
            }

            #endregion
        }
        else
        {
            paused = false;
            Interacted(null);
        }
    }

    public void StopInteract()
    {
        PauseDialog();
    }

    public void ShowInteractText(bool value)
    {
        textToToggle.SetActive(value);
    }
    private void OnTriggerEnter(Collider other)
    {
        ShowInteractText(true);
    }

    private void OnTriggerExit(Collider other)
    {
        PauseDialog();
        ShowInteractText(false);
    }

    private void Update()
    {
        if (IsTalking && !paused)
        {
            timer -= Time.deltaTime;
            
        }
        if (timer <= 0 && AutoTalk)
        {
            timer = 1;
            IsTalking = false;
            bookmark2++;
            Interacted(null);
            //Debug.Log("Done Talking");
        }
        if (bookmark == endOfDialogInt)
        {
            endOfDialogInt = 9999;
            StopDialog();
        }
    }

    public void PauseDialog()
    {
        textManager.DisplayTextBox(false);
        paused = true;
    }
    public void StopDialog()
    {
        textManager.DisplayTextBox(false);
        paused = true;
        ShowInteractText(true);
        bookmark = 0;
        bookmark2 = 0;
        if (hasSecondDialog)
        {
            secondRunning = true;
            
        }
    }
    
    
    //public int interactedNo;
    public TextManager textManager;
    // public void Interacted()
    // {
    //     DisplayDescription();
    // }
    //
    public void DisplayDescription(List<Description> DescriptionsToPlay)
    {
        textManager.TextToDisplay(DescriptionsToPlay[bookmark].statements[bookmark2].text);
    }
    
}
