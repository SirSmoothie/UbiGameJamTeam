using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour, IInteractable
{
    public void Interacted(GameObject Interactor)
    {
        TimeManager.Current.EndDay();
    }

    public void StopInteract()
    {
        throw new System.NotImplementedException();
    }
}
