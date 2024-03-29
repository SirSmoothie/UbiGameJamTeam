using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cohesian : MonoBehaviour
{
    public float cohesionStrength = 10f;

    private Rigidbody rb;
    private NeighboursRaycast neighboursScript;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        neighboursScript = GetComponent<NeighboursRaycast>();
    }

    void FixedUpdate()
    {
        Vector3 cohesionForce = CohesionForce(neighboursScript.neighbours);
        
        rb.AddForce(cohesionForce * cohesionStrength);
    }

    Vector3 CohesionForce(List<GameObject> neighbors)
    {
        Vector3 targetPosition = Vector3.zero;
        Vector3 myPosition = transform.position;
        
        if (neighbors.Count == 0)
            return Vector3.zero;

        foreach (GameObject neighbor in neighbors)
        {
            targetPosition += neighbor.transform.position;
            
            
        }
    
        if (neighbors.Count > 0)
        {
            targetPosition /= neighbors.Count;
            Vector3 directionTowardsTarget = (targetPosition - myPosition).normalized;
            return directionTowardsTarget;
        }

        return Vector3.zero;
    }
}