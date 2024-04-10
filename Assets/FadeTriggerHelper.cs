using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeTriggerHelper : MonoBehaviour
{
    public FadeUI fadeUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            fadeUI.UpdateFadeOnBool(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            fadeUI.UpdateFadeOnBool(false);
        }
    }
}
