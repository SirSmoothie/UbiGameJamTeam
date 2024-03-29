using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerceptionRadius : MonoBehaviour
{
    public float perceptionRadius = 0f;
    public NeighboursRaycast neighboursRaycast;
    public float maxDistance = 10f;
    public float minPerception = 0.1f;
    public float maxPerception = 1f;

    private void Start()
    {
        neighboursRaycast = GetComponent<NeighboursRaycast>();
    }

    void Update()
    {
        perceptionRadius = PerceptionNeighbours();
    }
    
    float PerceptionNeighbours()
    {
        float minDistance = float.MaxValue;
        
        foreach (GameObject neighbours in neighboursRaycast.neighbours)
        {
            float distanceToDetected = Vector3.Distance(transform.position, neighbours.transform.position);
            minDistance = Mathf.Min(minDistance, distanceToDetected);
        }
        
        float perception = 1f - Mathf.Clamp01(minDistance / maxDistance);
        perception = Mathf.Lerp(minPerception, maxPerception, perception);
        return perception;
    }
}
