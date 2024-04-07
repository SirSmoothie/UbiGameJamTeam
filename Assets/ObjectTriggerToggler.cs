using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTriggerToggler : MonoBehaviour
{
    public GameObject objectToTrigger;
    private void OnTriggerEnter(Collider other)
    {
        objectToTrigger.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        objectToTrigger.SetActive(false);
    }

    private void Awake()
    {
        objectToTrigger.SetActive(false);
    }
}
