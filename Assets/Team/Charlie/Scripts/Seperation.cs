using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seperation : MonoBehaviour
{
    public float seperationStrength;
    private Rigidbody rb;
    private NeighboursRaycast neighboursScript;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        neighboursScript = GetComponent<NeighboursRaycast>();
    }

    void FixedUpdate()
    {
        Vector3 seperationForce = SeperationForce(neighboursScript.neighbours);

        rb.AddForce(seperationForce * seperationStrength);
    }

    Vector3 SeperationForce(List<GameObject> neighbors)
    {
        Vector3 separationDirection = Vector3.zero;
        Vector3 myPosition = transform.position;

        
        if (neighbors.Count == 0)
            return Vector3.zero;

        foreach (GameObject neighbor in neighbors)
        {
            
            // subtract postion of object a from position of object b
            Vector3 awayFromNeighbour = myPosition - neighbor.transform.position;
            separationDirection += awayFromNeighbour;
            
            //  Vector3 normalizedDirection = awayFromNeighbour.normalized;
            //  normalizedDirection = (myPosition - neighbor.transform.position).normalized;
            // // separationDirection += toNeighbor.normalized / toNeighbor.magnitude; 
        }

        if (neighbors.Count > 0)
        {
            separationDirection /= neighbors.Count;
            separationDirection = separationDirection.normalized;
        }
        
        return separationDirection;

    }


}