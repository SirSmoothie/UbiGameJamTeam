using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectObject : MonoBehaviour, IInteractable
{
    public List<Description> descriptions;
    public int interactedNo;
    public TextManager textManager;
    public void Interacted()
    {
        DisplayDescription();
    }

    public void DisplayDescription()
    {
        interactedNo++;
        textManager.TextToDisplay(descriptions[interactedNo].details, descriptions[interactedNo].timeToDisplayMessage);
    }
}
