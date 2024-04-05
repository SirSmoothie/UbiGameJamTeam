using System;
using System.Collections;
using System.Collections.Generic;
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

    public void Interacted()
    {
        if (!paused)
        {
            #region FirstDialog

            if (!secondRunning)
            {
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
                    Interacted();
                }
                else if (bookmark <= descriptions.Count)
                {
                    DisplayDescription();
                    timer = descriptions[bookmark].statements[bookmark2].timeTillNextText;
                }

            }

            #endregion

            #region SecondDialog



            #endregion
        }
        else
        {
            paused = false;
            DisplayDescription();
        }
    }

    public void StopInteract()
    {
        StopDialog();
    }

    private void OnTriggerExit(Collider other)
    {
        StopDialog();
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
            Interacted();
            //Debug.Log("Done Talking");
        }

        if (bookmark == descriptions.Count)
        {
            StopDialog();
        }
    }

    public void StopDialog()
    {
        textManager.DisplayTextBox(false);
        paused = true;
    }
    
    
    //public int interactedNo;
    public TextManager textManager;
    // public void Interacted()
    // {
    //     DisplayDescription();
    // }
    //
    public void DisplayDescription()
    {
        textManager.TextToDisplay(descriptions[bookmark].statements[bookmark2].text);
    }
}
