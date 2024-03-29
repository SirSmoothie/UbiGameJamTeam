using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neighbours : MonoBehaviour
{
    public List<GameObject> neighbours = new List<GameObject>();
    
    void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger) 
        {
            if (!neighbours.Contains(other.gameObject))
            {
                neighbours.Add(other.gameObject);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.isTrigger) 
        {
            if (neighbours.Contains(other.gameObject))
            {
                neighbours.Remove(other.gameObject);
            }
        }
    }
}