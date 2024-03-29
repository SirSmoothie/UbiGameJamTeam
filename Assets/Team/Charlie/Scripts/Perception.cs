using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perception : MonoBehaviour
{
    public float perceptionAmount = 0f;
    public AIEyes aiEyes;
    public float maxDistance = 10f;
    public float minPerception = 0.1f;
    public float maxPerception = 1f;

    private void Start()
    {
        aiEyes = GetComponent<AIEyes>();
    }

    void Update()
    {
        perceptionAmount = PerceptionRaycast();
    }

    float PerceptionRaycast()
    {
        float minDistance = float.MaxValue;
        
        foreach (Transform detectedObject in aiEyes.detectedObjects)
        {
            float distanceToDetected = Vector3.Distance(transform.position, detectedObject.position);
            minDistance = Mathf.Min(minDistance, distanceToDetected);
        }
        
        float perception = 1f - Mathf.Clamp01(minDistance / maxDistance);
        perception = Mathf.Lerp(minPerception, maxPerception, perception);
        return perception;
    }




}
